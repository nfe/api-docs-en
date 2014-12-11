using Conube.Domain;
using Conube.Infrastructure;
using Fepin.Foundation.Logging;
using Fepin.MessageBus;
using Fepin.Persistence;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Conube.App.Api.Frontend.Controllers
{
    /// <summary>
    /// Notas Fiscais de Serviço
    /// </summary>
    [Authorize]
    [RoutePrefix("v1/companies/{company_id}/serviceinvoices")]
    public class ServiceInvoicesController : BaseAccountController
    {
        private static ILogger Log = null;
        private readonly ServiceInvoiceApplicationService _service;
        private readonly IPublisher _queue;
        private readonly IServiceInvoiceDocumentStorage _documentStorage;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="repository">Repositório de acesso as Empresas</param>
        /// <param name="queue">Fila padrão para processamento</param>
        /// <param name="service">Serviço para processamento de notas fiscais de serviço</param>
        public ServiceInvoicesController(
            IRepository<Account> repository,
            IPublisher queue,
            ServiceInvoiceApplicationService service,
            IServiceInvoiceDocumentStorage documentStorage)
            : base(repository)
        {
            Log = Log ?? LogManager.GetLogger<ServiceInvoicesController>();
            _queue = queue;
            _service = service;
            _documentStorage = documentStorage;
        }

        /**
         * @apiDefine ApiKeyNotValid
         *
         * @apiError UserNotFound The id of the User was not found.
         *
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 400 Not Found
         *     {
         *       "error": "UserNotFound"
         *     }
         */

        /**
         * @api {get} v1/companies/:company_id/serviceinvoices List all Service Invoices
         * @apiName GetAll
         * @apiGroup ServiceInvoices
         *
         * @apiParam {String} id Company unique ID.
         *
         * @apiSuccess {Number} totalResults Total results of resources.
         * @apiSuccess {Number} totalPages Total of pages.
         * @apiSuccess {Number} page Current page number.
         * @apiSuccess {Object[]} serviceInvoices List of Service invoices (Array of Objects).
         * @apiSuccess {String} serviceInvoices.id The Service Invoice unique ID.
         * @apiSuccess {String='Issued','Cancelled','WaitingCalculateTaxes','WaitingDefineRpsNumber','WaitingSend','WaitingSendCancel','WaitingReturn','WaitingDownload','CancelFailed','IssueFailed'} serviceInvoices.flowStatus The status of processing flow.
         * @apiSuccess {Object} serviceInvoices.provider Provider of services data as in tax registry.
         * @apiSuccess {String} serviceInvoices.provider.id The Provider unique ID.
         * @apiSuccess {Number} serviceInvoices.provider.federalTaxNumber Federal tax number.
         * @apiSuccess {String} serviceInvoices.provider.name Legal name of company.
         * @apiSuccess {String} [serviceInvoices.provider.tradeName] Trade name of company.
         * @apiSuccess {String} [serviceInvoices.provider.taxRegime] Company tax regime.
         * @apiSuccess {String} [serviceInvoices.provider.legalNature] Company legal nature.
         * @apiSuccess {Object} serviceInvoices.provider.address The address data.
         * @apiSuccess {String} serviceInvoices.provider.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
         * @apiSuccess {String} [serviceInvoices.provider.address.postalCode] Postal code, optional when abroad Brazil.
         * @apiSuccess {String} serviceInvoices.provider.address.street The street name.
         * @apiSuccess {String} [serviceInvoices.provider.address.number] The number of address.
         * @apiSuccess {String} [serviceInvoices.provider.address.additionalInformation] Any additional information of address.
         * @apiSuccess {String} [serviceInvoices.provider.address.district] District of address, optional when abroad Brazil.
         * @apiSuccess {Object} [serviceInvoices.provider.address.city] The city data.
         * @apiSuccess {Object} [serviceInvoices.provider.address.city.code] City code based on IBGE data.
         * @apiSuccess {Object} [serviceInvoices.provider.address.city.name] City name.
         * @apiSuccess {String} [serviceInvoices.provider.address.state] State abbreviation, optional when abroad Brazil.
         * @apiSuccess {Object} serviceInvoices.borrower Borrower of services data as in tax registry.
         * @apiSuccess {Number} [serviceInvoices.borrower.federalTaxNumber] Federal tax number, optional when abroad Brazil.
         * @apiSuccess {String} serviceInvoices.borrower.name Full name of person or legal entity.
         * @apiSuccess {String} serviceInvoices.borrower.email Email of borrower to receive the PDF and XML.
         * @apiSuccess {Object} serviceInvoices.borrower.address The address data.
         * @apiSuccess {String} serviceInvoices.borrower.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
         * @apiSuccess {String} [serviceInvoices.borrower.address.postalCode] Postal code, optional when abroad Brazil.
         * @apiSuccess {String} serviceInvoices.borrower.address.street The street name.
         * @apiSuccess {String} [serviceInvoices.borrower.address.number] The number of address.
         * @apiSuccess {String} [serviceInvoices.borrower.address.additionalInformation] Any additional information of address.
         * @apiSuccess {String} [serviceInvoices.borrower.address.district] District of address, optional when abroad Brazil.
         * @apiSuccess {Object} [serviceInvoices.borrower.address.city] The city data, optional when abroad Brazil.
         * @apiSuccess {Object} [serviceInvoices.borrower.address.city.code] City code based on IBGE data.
         * @apiSuccess {Object} [serviceInvoices.borrower.address.city.name] City name.
         * @apiSuccess {String} [serviceInvoices.borrower.address.state] State abbreviation, optional when abroad Brazil.
         * @apiSuccess {Number} serviceInvoices.batchNumber Service invoice batch number received from city.
         * @apiSuccess {Number} serviceInvoices.number Service invoice number created by the city.
         * @apiSuccess {String} serviceInvoices.checkCode Service invoice check code verification.
         * @apiSuccess {String='None','Created','Issued','Cancelled','Error'} serviceInvoices.status Invoice status.
         * @apiSuccess {String='Rps','RpsMista','Cupom'} serviceInvoices.rpsType RPS type.
         * @apiSuccess {String='Normal','Cancelled','Lost'} serviceInvoices.rpsStatus RPS status.
         * @apiSuccess {String} serviceInvoices.rpsSerialNumber Service invoice RPS Serial number.
         * @apiSuccess {Number} serviceInvoices.rpsSerialNumber Service invoice RPS number.
         * @apiSuccess {String='Nenhum','DentroMunicipio','ForaMunicipio','Exportacao','Isento','Imune','SuspensoDecisaoJudicial','SuspensoProcedimentoAdministrativo'} serviceInvoices.taxationType RPS status.
         * @apiSuccess {String} serviceInvoices.issuedOn Service invoice issued on date.
         * @apiSuccess {String} serviceInvoices.cityServiceCode City code of the provided service, contact accountant to get the correct code.
         * @apiSuccess {String} [serviceInvoices.federalServiceCode] Federal code of the provided service.
         * @apiSuccess {String} serviceInvoices.description Description of provided service.
         * @apiSuccess {Number} serviceInvoices.servicesAmount Total amount of service.
         * @apiSuccess {Number} serviceInvoices.deductionsAmount Deductions amount on service.
         * @apiSuccess {Number} serviceInvoices.discountUnconditionedAmount Deductions amount on service.
         * @apiSuccess {Number} serviceInvoices.discountConditionedAmount Deductions amount on service.
         * @apiSuccess {Number} serviceInvoices.baseTaxAmount Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.issRate Tax rate.
         * @apiSuccess {Number} serviceInvoices.iisTaxAmount Calculated tax amount.
         * @apiSuccess {Number} serviceInvoices.irAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.pisAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.cofinsAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.csllAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.inssAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.issAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.othersAmountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.amountWithheld Base amount for tax calculations.
         * @apiSuccess {Number} serviceInvoices.amountNet Base amount for tax calculations.
         * @apiSuccess {String} serviceInvoices.createdOn Date and time of creation.
         * @apiSuccess {String} serviceInvoices.modifiedOn Date and time of last modification.
         *
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         *     {
         *         "totalResults": 10,
         *         "totalPages": 1,
         *         "page": 1,
         *         "serviceInvoices": [
         *          {
         *              "id": "54879dec2916f90728a92fd2",
         *              "flowStatus": "Issued",
         *              "provider": {
         *                "id": "54879dec2916f90728a92fd2",
         *                "federalTaxNumber": 18792479000101,
         *                "name": "GABRIEL ALEJANDRO DA SILVA MARQUEZ - EPP",
         *                "tradeName": "CONUBE",
         *                "taxRegime": "SimplesNacional",
         *                "legalNature": "Empresario",
         *                "municipalTaxNumber": 48177687,
         *                "email": "",
         *                "address": {
         *                  "country": "",
         *                  "postalCode": "05761-280",
         *                  "street": "Rua João Baptista de Camargo",
         *                  "number": "58",
         *                  "additionalInformation": "",
         *                  "district": "Jardim Maria Virginia",
         *                  "city": {
         *                    "code": "3550308",
         *                    "name": "São Paulo"
         *                  },
         *                  "state": "SP"
         *                }
         *              },
         *              "borrower": {
         *                "name": "GABRIEL ALEJANDRO DA SILVA MARQUEZ",
         *                "federalTaxNumber": 36645999852,
         *                "email": "gblmarquez@hotmail.com",
         *                "address": {
         *                  "country": "BRA",
         *                  "postalCode": "05761280",
         *                  "street": "Rua João Baptista de Camargo",
         *                  "number": "58",
         *                  "additionalInformation": "",
         *                  "district": "Jd Maria Virginia",
         *                  "city": {
         *                  "code": "3550308",
         *                  "name": "São Paulo"
         *                  },
         *                  "state": "SP"
         *                },
         *                "status": "Active",
         *                "type": "Nenhum",
         *                "createdOn": "2014-12-10T01:12:12.1602396+00:00"
         *              },
         *              "batchNumber": 165784958,
         *              "number": 131,
         *              "checkCode": "SBDPCPEY",
         *              "status": "Issued",
         *              "rpsType": "Rps",
         *              "rpsStatus": "Normal",
         *              "taxationType": "Nenhum",
         *              "issuedOn": "2014-12-09T23:12:13.6932436-02:00",
         *              "rpsSerialNumber": "IO",
         *              "rpsNumber": 55,
         *              "cityServiceCode": "2690",
         *              "federalServiceCode": "1.04",
         *              "description": "TESTE EMISSAO",
         *              "servicesAmount": 0.01,
         *              "deductionsAmount": 0,
         *              "discountUnconditionedAmount": 0,
         *              "discountConditionedAmount": 0,
         *              "baseTaxAmount": 0.01,
         *              "issRate": 0.02,
         *              "issTaxAmount": 0.0002,
         *              "irAmountWithheld": 0,
         *              "pisAmountWithheld": 0,
         *              "cofinsAmountWithheld": 0,
         *              "csllAmountWithheld": 0,
         *              "inssAmountWithheld": 0,
         *              "issAmountWithheld": 0,
         *              "othersAmountWithheld": 0,
         *              "amountWithheld": 0,
         *              "amountNet": 0.01,
         *              "createdOn": "2014-12-10T01:12:12.1602396+00:00",
         *              "modifiedOn": "2014-12-10T01:13:03.4274719+00:00"
         *          }
         *      ]}
         *
         */
        /// <summary>
        /// Listar as Notas Fiscais de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="pageCount">Items por página</param>
        /// <param name="pageIndex">Número da página</param>
        /// <returns>Todas as Notas Fiscais de Serviço (NFSE), em todos os estados: Emitidas, Canceladas e com Erro</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(ServiceInvoiceCollectionResource))]
        public async Task<IHttpActionResult> Get(string company_id, int pageCount = 50, int pageIndex = 1)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                return ResponseResult(await _service.All(apikey.ParentId, company_id, pageCount, pageIndex));
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("Get({0})", company_id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Obter os detalhes de uma Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do API Key da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Retorna todos os dados da Nota Fiscal de Serviço (NFSE)</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(ServiceInvoiceResource))]
        public async Task<IHttpActionResult> Get(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var result = await _service.One(apikey.ParentId, company_id, id);

                return ResponseResult(result, e => this.Ok(new ServiceInvoiceResource(e)));
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("GetById({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Emitir uma Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da nota fiscal de serviço</param>
        /// <returns></returns>
        /// <response code="202">Nota Fiscal de Serviços foi enviada com sucesso para fila de emissão</response>
        /// <response code="400">API Key da empresa não é valida</response>
        /// <response code="500">Erro no processamento</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post(string company_id, ServiceInvoiceIssueMessage item)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");
                if (item == null)
                    return BadRequest("body is null");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.QueueSend(apikey.ParentId, company_id, item, s => { result = s.Item; token.Set(); }));

                return await Task.Run(() =>
                {
                    try
                    {
                        if (token.Wait(60000))
                        {
                            if (result.Status == ResultStatusCode.OK)
                            {
                                return AcceptedResponseResult(
                                        result,
                                        new Uri(Url.Route("ServiceInvoicesDefaultApi", new { controller = "serviceinvoices", company_id, id = result.ValueAsSuccess.Id }),
                                            UriKind.Relative));
                            }
                            return ResponseResult(result);
                        }
                        else
                        {
                            return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                        }
                    }
                    finally
                    {
                        token.Dispose();
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("Post({0})", company_id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Cancelar uma Nota Fiscal de Serviços (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <param name="webhookUrl">URL de retorno após o fim do processamento</param>
        /// <returns></returns>
        /// <response code="200">Nota fiscal cancelada com sucesso</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.QueueCancel(apikey.ParentId, company_id, id, s => { result = s.Result; token.Set(); }));

                return await Task.Run(() =>
                {
                    try
                    {
                        if (token.Wait(60000))
                        {
                            if (result.Status == ResultStatusCode.OK)
                            {
                                return AcceptedResponseResult(
                                        result,
                                        new Uri(Url.Route("ServiceInvoicesDefaultApi", new { controller = "serviceinvoices", company_id, id = result.ValueAsSuccess.Id }),
                                            UriKind.Relative));
                            }
                            return ResponseResult(result);
                        }
                        else
                        {
                            return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                        }
                    }
                    finally
                    {
                        token.Dispose();
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("Delete({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Enviar email para o Tomador com a Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Arquivo da Nota Fiscal de Serviço (NFSE) em PDF</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}/sendemail")]
        [HttpPut]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> SendEmail(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.ResendEmail(apikey.ParentId, company_id, id, s => { result = s.Result; token.Set(); }));

                return await Task.Run(() =>
                {
                    try
                    {
                        if (token.Wait(60000))
                        {
                            return ResponseResult<ServiceInvoice>(result, (e) =>
                            {
                                return Ok();
                            });
                        }
                        else
                        {
                            return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                        }
                    }
                    finally
                    {
                        token.Dispose();
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("SendEmail({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Download do PDF da Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Arquivo da Nota Fiscal de Serviço (NFSE) em PDF</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}/pdf")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetDocumentPdf(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.Download(apikey.ParentId, company_id, id, s => { result = s.Result; token.Set(); }));

                try
                {
                    if (token.Wait(60000))
                    {
                        return Redirect(await _documentStorage.BuildPdfUrl(result.ValueAsSuccess));
                    }
                    else
                    {
                        return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                    }
                }
                finally
                {
                    token.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("SendEmail({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Download do XML da Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Arquivo da Nota Fiscal de Serviço (NFSE) em PDF</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}/xml")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetDocumentXml(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.Download(apikey.ParentId, company_id, id, s => { result = s.Result; token.Set(); }));

                try
                {
                    if (token.Wait(60000))
                    {
                        return Redirect(await _documentStorage.BuildXmlUrl(result.ValueAsSuccess));
                    }
                    else
                    {
                        return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                    }
                }
                finally
                {
                    token.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("SendEmail({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Reprocessar Nota Fiscal de Serviço (NFSE)
        /// </summary>
        /// <remarks>Você precisará do APIKEY da Empresa</remarks>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Arquivo da Nota Fiscal de Serviço (NFSE) em PDF</returns>
        /// <response code="200">Sucesso na requisição</response>
        /// <response code="400">API Key da empresa não é valida</response>
        [Route("{id}/retry")]
        [HttpPut]
        [ResponseType(typeof(string))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> RetryProcess(string company_id, string id)
        {
            try
            {
                var apikey = this.ApiKey;
                if (apikey == null || apikey.Description.IndexOf("api.nfe.io") < 0)
                    return BadRequest("account api key is not valid");

                var token = new ManualResetEventSlim(false);
                Result<ServiceInvoice> result = null;

                _queue.Publish(new ServiceInvoiceMessages.QueueRetry(apikey.ParentId, company_id, id, s => { result = s.Result; token.Set(); }));

                return await Task.Run(() =>
                {
                    try
                    {
                        if (token.Wait(60000))
                        {
                            return ResponseResult<ServiceInvoice>(result, (e) =>
                            {
                                return Ok();
                            });
                        }
                        else
                        {
                            return this.ResponseMessage(new HttpResponseMessage(HttpStatusCode.RequestTimeout));
                        }
                    }
                    finally
                    {
                        token.Dispose();
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Fatal(string.Format("RetryProcess({0}, {1})", company_id, id), ex);
                return InternalServerError();
            }
        }
    }
}
