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
    public class KontaktGutscheinModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KontaktGutscheinModule(KontaktGutscheinService kontaktGutscheinService)
            : base("/kontaktGutscheine")
        {
            Get["/"] = p =>
            {
                var kontaktGutscheine= kontaktGutscheinService.Get();
                return new JsonResponse(kontaktGutscheine, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kontaktGutschein = kontaktGutscheinService.Get(p.id);
                if(kontaktGutschein == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kontaktGutschein, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                KontaktGutschein post = this.Bind();
                try
                {
                    var result = kontaktGutscheinService.Add(post);
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
                KontaktGutschein put = this.Bind();
                try
                {
                    var result = kontaktGutscheinService.Update(put);
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
                    var result = kontaktGutscheinService.Delete(p.id);
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
