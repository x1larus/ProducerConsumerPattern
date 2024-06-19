namespace ProducerConsumerPattern
{
    internal class ProducerConsumerExample
    {
        private const int ProducerCount = 5;
        private const int ConsumerCount = 1;
        private const int ProducerMaxSleep = 5000;
        private const int ConsumerMaxSleep = 5000;
        
        private const int QueueCapacity = 10;
        private readonly BlockingQueue<DataEntity> _blockingQueue = new BlockingQueue<DataEntity>(QueueCapacity);

        private void ProducerFunction(int id)
        {
            var rand = new Random();
            while (true)
            {
                Thread.Sleep(rand.Next(0, ProducerMaxSleep));
                var data = new DataEntity
                {
                    Id = IdHelper.GetNextId(),
                    ProducerId = id,
                    TimeProduced = DateTime.Now.TimeOfDay,
                };

                _blockingQueue.PushItem(data);
                ConsoleLogHelper.Log($"Producer {id}: created DataEntity " + data.GetProducerReportString(), ConsoleColor.Yellow);
            }
        }

        private void ConsumerFunction(int id)
        {
            var rand = new Random();
            while (true)
            {
                var data = _blockingQueue.GetItem();

                data.TimeConsumed = DateTime.Now.TimeOfDay;

                ConsoleLogHelper.Log($"Consumer {id}: get DataEntity " + data.GetConsumerReportString(), ConsoleColor.Green);
                
                Thread.Sleep(rand.Next(0, ConsumerMaxSleep));
            }
        }

        public void Run()
        {
            // Create producers
            var producerTasks = new Task[ProducerCount];
            for (var i = 0; i < ProducerCount; i++)
            {
                var i1 = i;
                producerTasks[i] = Task.Factory.StartNew(() => { ProducerFunction(i1); });
            }

            // Create consumers
            var consumerTasks = new Task[ConsumerCount];
            for (var i = 0; i < ConsumerCount; i++)
            {
                var i1 = i;
                consumerTasks[i] = Task.Factory.StartNew(() => { ConsumerFunction(i1); });
            }
        }
    }
}
