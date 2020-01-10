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
    public class KassabuchModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KassabuchModule(KassabuchService kassabuchService)
            : base("/kassabuecher")
        {
            Get["/"] = p =>
            {
                var kassabuecher= kassabuchService.Get();
                return new JsonResponse(kassabuecher, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kassabuch = kassabuchService.Get(p.id);
                if(kassabuch == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kassabuch, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kassabuch post = this.Bind();
                try
                {
                    var result = kassabuchService.Add(post);
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
                Kassabuch put = this.Bind();
                try
                {
                    var result = kassabuchService.Update(put);
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
                    var result = kassabuchService.Delete(p.id);
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
