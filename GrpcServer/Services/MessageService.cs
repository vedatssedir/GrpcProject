using Grpc.Core;
using grpcMessageServer;

namespace GrpcServer.Services
{
    public class MessageService : Message.MessageBase
    {
        private readonly ILogger<MessageService> _logger;
        public MessageService(ILogger<MessageService> logger)
        {
            _logger = logger;
        }

        public override async Task<MessageResponse> Send(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        {

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                Console.WriteLine($"Message : {requestStream.Current.Message} | Name : {requestStream.Current.Name}");
            }
            return new MessageResponse()
            {
                Message = "Veri alınmıştır..."
            };
        }


        //public override async Task Send(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        //{
        //    Console.WriteLine($"Message : {request.Message} Name: {request.Name}");
        //    for (var i = 0; i < 100000; i++)
        //    {
        //        await responseStream.WriteAsync(new MessageResponse() { Message = $"Item : {i}", Name = "Vedat Sedir" });
        //    }
        //}




        //public override Task Send(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        //{


        //    for (var i = 0; i < 10; i++)
        //    {
        //        Task.Delay(200);
        //        responseStream.WriteAsync(new MessageResponse()
        //        {
        //            Name = "Vedat Sedir",
        //            Message = "Test amaclıdır"
        //        });
        //    }


        //    return responseStream.WriteAsync(new MessageResponse() );

        //}



    }
}
