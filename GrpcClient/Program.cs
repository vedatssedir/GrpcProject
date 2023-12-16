using Grpc.Net.Client;
using grpcMessageServer;
using GrpcServer;

namespace GrpcClient;

internal class Program
{
    static async Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress(new Uri("https://localhost:7265"));


        //var greetClient = new Greeter.GreeterClient(channel);

        //var result = await greetClient.SayHelloAsync(new HelloRequest()
        //{
        //    Name = "Vedat Sedir"
        //});

        //var messageClient = new Message.MessageClient(channel);
        //var messageResponse = messageClient.Send(new MessageRequest() { Message = "test", Name = "vedat" });
        //var cancellationTokenSource = new CancellationTokenSource();

        //while (await messageResponse.ResponseStream.MoveNext(cancellationTokenSource.Token))
        //{
        //    Console.WriteLine(messageResponse.ResponseStream.Current);
        //}


        //Server Streaming
        //var messageClient = new Message.MessageClient(channel);

        //var message = await messageClient.Send(new MessageRequest()
        //{
        //    Name = "Vedat Sedir",
        //    Message = "Bu test amaclıdır"
        //});
        //Console.WriteLine($"{result.Message} : {message.Message}");
        //Console.ReadLine();

        //Client Streaming
        var messageClient = new Message.MessageClient(channel);
        var request = messageClient.Send();

        for (int i = 0; i < 10; i++)
        {
            await request.RequestStream.WriteAsync(new MessageRequest() { Message = $"Mesaj {i}", Name = "Vedat Sedir" });
        }
        await request.RequestStream.CompleteAsync();
        Console.WriteLine((await request.ResponseAsync).Message);



        Console.ReadLine();
    }




}