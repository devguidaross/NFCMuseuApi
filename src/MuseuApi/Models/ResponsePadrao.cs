namespace MuseuApi.Models
{
    public class ResponsePadrao
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public int Codigo { get; set; }
        
        public object Data { get; set; }
    }
}