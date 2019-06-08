using System.Collections.Generic;

namespace Lojinha.DonaMaria.Request
{
    public class InternalServerErrorResponseModel
    {
        public InternalServerErrorResponseModel()
        {
            Message = "Ocorreu um erro, tente novamente mais tarde ou entre em contato com o suporte técnico.";
        }

        public InternalServerErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

    }

    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
            Message = "O modelo fornecido é inválido.";
        }

        public ErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public List<ItemErrorResponseModel> Errors { get; set; }
    }

    public class ItemErrorResponseModel
    {
        public ItemErrorResponseModel()
        {
        }

        public ItemErrorResponseModel(string field)
        {
            Field = field;
        }

        public ItemErrorResponseModel(string field, List<string> messages)
        {
            Field = field;
            Messages = messages;
        }

        public string Field { get; set; }
        public List<string> Messages { get; set; }
    }
}
