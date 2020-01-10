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
    public class SozialgruppeModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public SozialgruppeModule(SozialgruppeService sozialgruppeService)
            : base("/sozialgruppen")
        {
            Get["/"] = p =>
            {
                var sozialgruppen= sozialgruppeService.Get();
                return new JsonResponse(sozialgruppen, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var sozialgruppe = sozialgruppeService.Get(p.id);
                if(sozialgruppe == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(sozialgruppe, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Sozialgruppe post = this.Bind();
                try
                {
                    var result = sozialgruppeService.Add(post);
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
                Sozialgruppe put = this.Bind();
                try
                {
                    var result = sozialgruppeService.Update(put);
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
                    var result = sozialgruppeService.Delete(p.id);
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
