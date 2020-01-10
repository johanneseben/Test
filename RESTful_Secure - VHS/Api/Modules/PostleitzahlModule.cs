using Common.Services;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Common.Models;
using Nancy.Serialization.JsonNet;
using Nancy.Security;

namespace Api.Modules
{
    public class PostleitzahlModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public PostleitzahlModule(PostleitzahlService postleitzahlService)
            : base("/postleitzahlen")
        {
            Get["/"] = p =>
            {
                var postleitzahlen= postleitzahlService.Get();
                return new JsonResponse(postleitzahlen, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var postleitzahl = postleitzahlService.Get(p.id);
                if(postleitzahl == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(postleitzahl, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Postleitzahl post = this.Bind();
                try
                {
                    var result = postleitzahlService.Add(post);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            };

            Put["/"] = p =>
            {
                Postleitzahl put = this.Bind();
                try
                {
                    var result = postleitzahlService.Update(put);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            };

            Delete["/{id}"] = p =>
            {
                try
                {
                    var result = postleitzahlService.Delete(p.id);
                    return new JsonResponse(result, new DefaultJsonSerializer());
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
