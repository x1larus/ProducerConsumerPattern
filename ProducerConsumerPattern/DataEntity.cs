namespace ProducerConsumerPattern
{
    internal class DataEntity
    {
        public int Id { get; set; }
        public TimeSpan TimeProduced { get; set; }
        public TimeSpan TimeConsumed { get; set; }
        public int ProducerId { get; set; }

        public string GetProducerReportString()
        {
            return $"id={Id} TimeProduced={TimeProduced}";
        }
        public string GetConsumerReportString()
        {
            return $"id={Id} ProducerId={ProducerId} TimeFromProducerToConsumer={ Math.Truncate((TimeConsumed-TimeProduced).TotalMilliseconds) }ms";
        }
    }
}
