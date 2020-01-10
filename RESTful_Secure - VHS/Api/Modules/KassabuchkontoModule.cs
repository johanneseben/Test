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
    public class KassabuchkontoModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KassabuchkontoModule(KassabuchkontoService kassabuchkontoService)
            : base("/kassabuchkonten")
        {
            Get["/"] = p =>
            {
                var kassabuchkonten= kassabuchkontoService.Get();
                return new JsonResponse(kassabuchkonten, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kassabuchkonto = kassabuchkontoService.Get(p.id);
                if(kassabuchkonto == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kassabuchkonto, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kassabuchkonto post = this.Bind();
                try
                {
                    var result = kassabuchkontoService.Add(post);
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
                Kassabuchkonto put = this.Bind();
                try
                {
                    var result = kassabuchkontoService.Update(put);
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
                    var result = kassabuchkontoService.Delete(p.id);
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
