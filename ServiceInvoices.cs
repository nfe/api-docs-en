/**
* 
* @apiDefine Unauthorized
*
* @apiError Unauthorized API Key access was denied (401 HTTP Status).
*/

/**
*
* @apiDefine CompanyNotFound
*
* @apiError CompanyNotFound Company unique ID was not found (404 HTTP Status).
*/

/**
*
* @apiDefine ServiceInvoiceNotFound
*
* @apiError ServiceInvoiceNotFound Service invoice was not found based on the ID (404 HTTP Status).
*/

/**
*
* @apiDefine InvalidPageNumberOrCount
*
* @apiError InvalidPageNumberOrCount Page number or count are out of range or less than 0 (403 HTTP Status).
*/

/// <summary>
/// Notas Fiscais de Serviço
/// </summary>
[Authorize]
[RoutePrefix("v1/companies/{company_id}/serviceinvoices")]
public class ServiceInvoicesController : BaseAccountController
{
    /**
    * @api {get} companies/:company_id/serviceinvoices?pageCount=:page_count&pageIndex=:page_index List all service invoices
    * @apiName GetAll
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {Number} page_count Items per page.
    * @apiParam {Number} page_index Page number.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse InvalidPageNumberOrCount
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
    * @apiSuccess {String} [serviceInvoices.provider.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} serviceInvoices.provider.address.street The street name.
    * @apiSuccess {String} [serviceInvoices.provider.address.number] The number of address.
    * @apiSuccess {String} [serviceInvoices.provider.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [serviceInvoices.provider.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [serviceInvoices.provider.address.city] The city data.
    * @apiSuccess {Object} [serviceInvoices.provider.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [serviceInvoices.provider.address.city.name] City name.
    * @apiSuccess {String} [serviceInvoices.provider.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {Object} serviceInvoices.borrower Borrower of services data as in tax registry.
    * @apiSuccess {Number} [serviceInvoices.borrower.federalTaxNumber] Federal tax number, optional foreign borrowers.
    * @apiSuccess {String} serviceInvoices.borrower.name Full name of person or legal entity.
    * @apiSuccess {String} serviceInvoices.borrower.email Email of borrower to receive the PDF and XML.
    * @apiSuccess {Object} serviceInvoices.borrower.address The address data.
    * @apiSuccess {String} serviceInvoices.borrower.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiSuccess {String} [serviceInvoices.borrower.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} serviceInvoices.borrower.address.street The street name.
    * @apiSuccess {String} [serviceInvoices.borrower.address.number] The number of address.
    * @apiSuccess {String} [serviceInvoices.borrower.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [serviceInvoices.borrower.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [serviceInvoices.borrower.address.city] The city data, optional foreign borrowers.
    * @apiSuccess {Object} [serviceInvoices.borrower.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [serviceInvoices.borrower.address.city.name] City name.
    * @apiSuccess {String} [serviceInvoices.borrower.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {Number} serviceInvoices.batchNumber Service invoice batch number received from city.
    * @apiSuccess {Number} serviceInvoices.number Service invoice number created by the city.
    * @apiSuccess {String} serviceInvoices.checkCode Service invoice check code verification.
    * @apiSuccess {String='None','Created','Issued','Cancelled','Error'} serviceInvoices.status Invoice status.
    * @apiSuccess {String='Rps','RpsMista','Cupom'} serviceInvoices.rpsType RPS type.
    * @apiSuccess {String='Normal','Canceled','Lost'} serviceInvoices.rpsStatus RPS status.
    * @apiSuccess {String} serviceInvoices.rpsSerialNumber Service invoice RPS Serial number.
    * @apiSuccess {Number} serviceInvoices.rpsSerialNumber Service invoice RPS number.
    * @apiSuccess {String='None','WithinCity','OutsideCity','Export','Free','Immune','SuspendedCourtDecision','SuspendedAdministrativeProcedure'} [serviceInvoices.taxationType] Taxation type based on city law.
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
    *                "federalTaxNumber": 00000000000191,
    *                "name": "BANCO DO BRASIL SA",
    *                "tradeName": "",
    *                "taxRegime": "LucroReal",
    *                "legalNature": "SociedadeAnonima",
    *                "municipalTaxNumber": 123456789,
    *                "email": "",
    *                "address": {
    *                  "country": "",
    *                  "postalCode": "70073-901",
    *                  "street": "Outros Quadra 1 Bloco G Lote 32",
    *                  "number": "S/N",
    *                  "additionalInformation": "QUADRA 01 BLOCO G",
    *                  "district": "Asa Sul",
    *                  "city": {
    *                    "code": "5300108",
    *                    "name": "Brasilia"
    *                  },
    *                  "state": "DF"
    *                }
    *              },
    *              "borrower": {
    *                "name": "JOSE MARIA TRINDADE",
    *                "federalTaxNumber": 11111111111,
    *                "email": "jose@hotmail.com",
    *                "address": {
    *                  "country": "BRA",
    *                  "postalCode": "06754-280",
    *                  "street": "Rua João Camargo",
    *                  "number": "99",
    *                  "additionalInformation": "",
    *                  "district": "Parque Laguna",
    *                  "city": {
    *                    "code": "3550308",
    *                    "name": "São Paulo"
    *                  },
    *                  "state": "SP"
    *                }
    *              },
    *              "batchNumber": 165784958,
    *              "number": 999,
    *              "checkCode": "SBDPCPEY",
    *              "status": "Issued",
    *              "rpsType": "Rps",
    *              "rpsStatus": "Normal",
    *              "taxationType": "WithinCity",
    *              "issuedOn": "2014-12-09T23:12:13.6932436-02:00",
    *              "rpsSerialNumber": "IO",
    *              "rpsNumber": 55,
    *              "cityServiceCode": "2690",
    *              "federalServiceCode": "1.04",
    *              "description": "TEST DESCRIPTION",
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
    { }

    /**
    * @api {get} companies/:company_id/serviceinvoices/:id Get service invoice details
    * @apiName Get
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {String} id Service invoice unique ID.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse ServiceInvoiceNotFound
    *
    * @apiSuccess {String} id The Service Invoice unique ID.
    * @apiSuccess {String='Issued','Cancelled','WaitingCalculateTaxes','WaitingDefineRpsNumber','WaitingSend','WaitingSendCancel','WaitingReturn','WaitingDownload','CancelFailed','IssueFailed'} serviceInvoices.flowStatus The status of processing flow.
    * @apiSuccess {Object} provider Provider of services data as in tax registry.
    * @apiSuccess {String} provider.id The Provider unique ID.
    * @apiSuccess {Number} provider.federalTaxNumber Federal tax number.
    * @apiSuccess {String} provider.name Legal name of company.
    * @apiSuccess {String} [provider.tradeName] Trade name of company.
    * @apiSuccess {String} [provider.taxRegime] Company tax regime.
    * @apiSuccess {String} [provider.legalNature] Company legal nature.
    * @apiSuccess {Object} provider.address The address data.
    * @apiSuccess {String} provider.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiSuccess {String} [provider.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} provider.address.street The street name.
    * @apiSuccess {String} [provider.address.number] The number of address.
    * @apiSuccess {String} provider.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [provider.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [provider.address.city] The city data.
    * @apiSuccess {Object} [provider.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [provider.address.city.name] City name.
    * @apiSuccess {String} [provider.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {Object} borrower Borrower of services data as in tax registry.
    * @apiSuccess {Number} [borrower.federalTaxNumber] Federal tax number, optional foreign borrowers.
    * @apiSuccess {String} borrower.name Full name of person or legal entity.
    * @apiSuccess {String} borrower.email Email of borrower to receive the PDF and XML.
    * @apiSuccess {Object} borrower.address The address data.
    * @apiSuccess {String} borrower.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiSuccess {String} [borrower.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} borrower.address.street The street name.
    * @apiSuccess {String} [borrower.address.number] The number of address.
    * @apiSuccess {String} [borrower.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [borrower.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [borrower.address.city] The city data, optional foreign borrowers.
    * @apiSuccess {Object} [borrower.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [borrower.address.city.name] City name.
    * @apiSuccess {String} [borrower.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {Number} batchNumber Service invoice batch number received from city.
    * @apiSuccess {Number} number Service invoice number created by the city.
    * @apiSuccess {String} checkCode Service invoice check code verification.
    * @apiSuccess {String='None','Created','Issued','Cancelled','Error'} status Invoice status.
    * @apiSuccess {String='Rps','RpsMista','Cupom'} rpsType RPS type.
    * @apiSuccess {String='Normal','Cancelled','Lost'} rpsStatus RPS status.
    * @apiSuccess {String} rpsSerialNumber Service invoice RPS Serial number.
    * @apiSuccess {Number} rpsSerialNumber Service invoice RPS number.
    * @apiSuccess {String='None','WithinCity','OutsideCity','Export','Free','Immune','SuspendedCourtDecision','SuspendedAdministrativeProcedure'} [serviceInvoices.taxationType] Taxation type based on city law.
    * @apiSuccess {String} issuedOn Service invoice issued on date.
    * @apiSuccess {String} cityServiceCode City code of the provided service, contact accountant to get the correct code.
    * @apiSuccess {String} [federalServiceCode] Federal code of the provided service.
    * @apiSuccess {String} description Description of provided service.
    * @apiSuccess {Number} servicesAmount Total amount of service.
    * @apiSuccess {Number} deductionsAmount Deductions amount on service.
    * @apiSuccess {Number} discountUnconditionedAmount Deductions amount on service.
    * @apiSuccess {Number} discountConditionedAmount Deductions amount on service.
    * @apiSuccess {Number} baseTaxAmount Base amount for tax calculations.
    * @apiSuccess {Number} issRate Tax rate.
    * @apiSuccess {Number} iisTaxAmount Calculated tax amount.
    * @apiSuccess {Number} irAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} pisAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} cofinsAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} csllAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} inssAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} issAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} othersAmountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} amountWithheld Base amount for tax calculations.
    * @apiSuccess {Number} amountNet Base amount for tax calculations.
    * @apiSuccess {String} createdOn Date and time of creation.
    * @apiSuccess {String} modifiedOn Date and time of last modification.
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 200 OK
    *     {
    *        "id": "54879dec2916f90728a92fd2",
    *        "flowStatus": "Issued",
    *        "provider": {
    *          "id": "54879dec2916f90728a92fd2",
    *          "federalTaxNumber": 00000000000191,
    *          "name": "BANCO DO BRASIL SA",
    *          "tradeName": "",
    *          "taxRegime": "LucroReal",
    *          "legalNature": "SociedadeAnonima",
    *          "municipalTaxNumber": 0123456,
    *          "email": "",
    *          "address": {
    *            "country": "BRA",
    *            "postalCode": "70073901",
    *            "street": "Outros Quadra 1 Bloco G Lote 32",
    *            "number": "S/N",
    *            "additionalInformation": "QUADRA 01 BLOCO G",
    *            "district": "Asa Sul",
    *            "city": {
    *              "code": "5300108",
    *              "name": "Brasilia"
    *            },
    *            "state": "DF"
    *          }
    *        },
    *        "borrower": {
    *          "name": "JOSE MARIA DA SILVA",
    *          "federalTaxNumber": 11111111111,
    *          "email": "jose@hotmail.com",
    *          "address": {
    *            "country": "BRA",
    *            "postalCode": "02310100",
    *            "street": "Av Paulista",
    *            "number": "2300",
    *            "additionalInformation": "",
    *            "district": "Bela Vista",
    *            "city": {
    *              "code": "3550308",
    *              "name": "São Paulo"
    *            },
    *            "state": "SP"
    *          }
    *        },
    *        "batchNumber": 165784958,
    *        "number": 999,
    *        "checkCode": "SBDPCPEY",
    *        "status": "Issued",
    *        "rpsType": "Rps",
    *        "rpsStatus": "Normal",
    *        "taxationType": "Nenhum",
    *        "issuedOn": "2014-12-09T23:12:13.6932436-02:00",
    *        "rpsSerialNumber": "IO",
    *        "rpsNumber": 55,
    *        "cityServiceCode": "2690",
    *        "federalServiceCode": "1.04",
    *        "description": "TEST DESCRIPTION",
    *        "servicesAmount": 0.01,
    *        "deductionsAmount": 0,
    *        "discountUnconditionedAmount": 0,
    *        "discountConditionedAmount": 0,
    *        "baseTaxAmount": 0.01,
    *        "issRate": 0.02,
    *        "issTaxAmount": 0.0002,
    *        "irAmountWithheld": 0,
    *        "pisAmountWithheld": 0,
    *        "cofinsAmountWithheld": 0,
    *        "csllAmountWithheld": 0,
    *        "inssAmountWithheld": 0,
    *        "issAmountWithheld": 0,
    *        "othersAmountWithheld": 0,
    *        "amountWithheld": 0,
    *        "amountNet": 0.01,
    *        "createdOn": "2014-12-10T01:12:12.1602396+00:00",
    *        "modifiedOn": "2014-12-10T01:13:03.4274719+00:00"
    *   }
    */
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
    { }

    /**
    * @api {post} companies/:company_id/serviceinvoices Issue a service invoice
    * @apiName Issue
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {Object} borrower Borrower of services data as in tax registry.
    * @apiParam {Number} [borrower.federalTaxNumber] Federal tax number, optional foreign borrowers.
    * @apiParam {String} borrower.name Full name of person or legal entity.
    * @apiParam {String} borrower.email Email of borrower to receive the PDF and XML.
    * @apiParam {Object} borrower.address The address data.
    * @apiParam {String} borrower.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiParam {String} [borrower.address.postalCode] Postal code, optional foreign borrowers.
    * @apiParam {String} borrower.address.street The street name.
    * @apiParam {String} [borrower.address.number] The number of address, optional foreign borrowers.
    * @apiParam {String} [borrower.address.additionalInformation] Any additional information of address.
    * @apiParam {String} [borrower.address.district] District of address, optional foreign borrowers.
    * @apiParam {Object} [borrower.address.city] The city data, optional foreign borrowers.
    * @apiParam {Object} [borrower.address.city.code] City code based on IBGE data.
    * @apiParam {Object} [borrower.address.city.name] City name.
    * @apiParam {String} [borrower.address.state] State abbreviation, optional foreign borrowers.
    * @apiParam {String} cityServiceCode City code of the provided service, contact accountant to get the correct code.
    * @apiParam {String} description Description of provided service.
    * @apiParam {Number} servicesAmount Total amount of service.
    * @apiParam {String} [rpsSerialNumber] Service invoice request batch serial number.
    * @apiParam {Number} [rpsNumber] Service invoice request batch number.
    * @apiParam {String} [issuedOn] Service invoice issued on date.
    * @apiParam {String='None','WithinCity','OutsideCity','Export','Free','Immune','SuspendedCourtDecision','SuspendedAdministrativeProcedure'} [serviceInvoices.taxationType] Taxation type based on city law.
    * @apiParam {Number} [issRate] ISS tax rate.
    * @apiParam {Number} [deductionsAmount] Deductions amount on service.
    * @apiParam {Number} [discountUnconditionedAmount] Deductions amount on service.
    * @apiParam {Number} [discountConditionedAmount] Deductions amount on service.
    * @apiParam {Number} [baseTaxAmount] Base amount for tax calculations.
    * @apiParam {Number} [iisTaxAmount] Calculated tax amount.
    * @apiParam {Number} [irAmountWithheld] IR amount tax withheld.
    * @apiParam {Number} [pisAmountWithheld] PIS amount tax withheld.
    * @apiParam {Number} [cofinsAmountWithheld] COFINS amount tax withheld.
    * @apiParam {Number} [csllAmountWithheld] CSLL amount tax withheld.
    * @apiParam {Number} [inssAmountWithheld] INSS amount tax withheld.
    * @apiParam {Number} [issAmountWithheld] ISS amount tax withheld.
    * @apiParam {Number} [othersAmountWithheld] Others Amount tax withheld.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse ServiceInvoiceNotFound
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 202 Accepted
    *     Location: v1/companies/:company_id/serviceinvoices/:id
    */
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
    { }

    /**
    * @api {delete} companies/:company_id/serviceinvoices/:id Cancel a service invoice
    * @apiName Cancel
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {String} id Service invoice unique ID.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse ServiceInvoiceNotFound
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 202 Accepted
    *     Location: v1/companies/:company_id/serviceinvoices/:id
    */
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
    { }

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
    { }

    /**
    * @api {get} companies/:company_id/serviceinvoices/:id/pdf Get PDF file of service invoice
    * @apiName GetPdf
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {String} id Service invoice unique ID.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse ServiceInvoiceNotFound
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 302 Found
    *     Location: Location of file
    */
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
    { }

    /**
    * @api {get} companies/:company_id/serviceinvoices/:id/xml Get XML file of service invoice
    * @apiName GetXml
    * @apiGroup Service Invoices
    *
    * @apiParam {String} company_id Company unique ID.
    * @apiParam {String} id Service invoice unique ID.
    *
    * @apiUse Unauthorized
    * @apiUse CompanyNotFound
    * @apiUse ServiceInvoiceNotFound
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 302 Found
    *     Location: Location of file
    */
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
    { }
}