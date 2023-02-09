using NoteBookAPI.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class ErrorManage
    {
        public ErrorDto ReturningError(string statuscode, string description) {
            ErrorDto response = new ErrorDto();
            switch (statuscode)
            {
                case "404":
                    response.Message = "Not Found";
                    break;
                case "400":
                    response.Message = "Bad Request";
                    break;
                case "401":
                    response.Message = "Unauthorized";
                    break;
                case "500":
                    response.Message = "Internal server error";
                    break;
                case "409":
                    response.Message = "Conflict";
                    break;
            }
            response.StatusCode = statuscode;
            response.Description = description;
            return response;
        }
    }
}
