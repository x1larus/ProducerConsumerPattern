namespace ProducerConsumerPattern
{
    internal class BlockingQueue<T> where T : DataEntity
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly int _maxSize;

        public BlockingQueue(int maxSize) => _maxSize = maxSize;

        public int Count => _queue.Count;

        public void PushItem(T item)
        {
            lock (_queue)
            {
                while (_queue.Count >= _maxSize)
                {
                    ConsoleLogHelper.Log("BlockingQueue is full!", ConsoleColor.Red);
                    Monitor.Wait(_queue);
                }

                _queue.Enqueue(item);

                if (_queue.Count == 1)
                {
                    Monitor.PulseAll(_queue);
                }
            }
        }

        public T GetItem()
        {
            T item;
            
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(_queue);
                }

                item = _queue.Dequeue();

                if (_queue.Count > 0)
                {
                    Monitor.PulseAll(_queue);
                }
            }

            return item;
        }
    }
}
