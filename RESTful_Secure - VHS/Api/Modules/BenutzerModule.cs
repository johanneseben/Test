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
    public class BenutzerModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public BenutzerModule(BenutzerService benutzerService)
            : base("/benutzer")
        {
            Get["/"] = p =>
            {
                var benutzer= benutzerService.Get();
                return new JsonResponse(benutzer, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var benutzer = benutzerService.Get(p.id);
                if(benutzer == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(benutzer, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Benutzer post = this.Bind();
                try
                {
                    var result = benutzerService.Add(post);
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
                Benutzer put = this.Bind();
                try
                {
                    var result = benutzerService.Update(put);
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
                    var result = benutzerService.Delete(p.id);
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
