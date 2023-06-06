internal class Program
{
   public static async Task Main(string[] args)
   {
      async Task<int> example(CancellationToken c)
      {

         await Task.Delay(10000);
         
         throw new Exception("Test");
         
         if (!c.IsCancellationRequested) return 0;
         return -1;
      }

      var c = new CancellationTokenSource();

      using var stream = new MemoryStream();
      
      //c.Cancel();

      try
      {

         await example(c.Token);

      }
      catch (Exception err)
      {
         Console.Write("Catched!");
      }
   }
}