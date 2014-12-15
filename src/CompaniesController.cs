/// <summary>
/// Empresas
/// </summary>
[Authorize]
[RoutePrefix("v1/companies")]
public class CompaniesController
{
  /**
    * @api {get} companies List all companies
    * @apiName GetAll
    * @apiGroup Companies
    *
    * @apiUse Unauthorized
    *
    * @apiSuccess {Object[]} companies List of Companies (Array of Objects).
    * @apiSuccess {String} companies.id The Company unique ID.
    * @apiSuccess {Number} companies.federalTaxNumber Federal tax number.
    * @apiSuccess {String} companies.name Legal name of company.
    * @apiSuccess {String} [companies.tradeName] Trade name of company.
    * @apiSuccess {String} companies.email Email of company.    
    * @apiSuccess {Object} companies.address The address data.
    * @apiSuccess {String} companies.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiSuccess {String} [companies.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} companies.address.street The street name.
    * @apiSuccess {String} [companies.address.number] The number of address.
    * @apiSuccess {String} [companies.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [companies.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [companies.address.city] The city data.
    * @apiSuccess {Object} [companies.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [companies.address.city.name] City name.
    * @apiSuccess {String} [companies.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {String} [companies.openningDate] Company openning date.
    * @apiSuccess {String='LucroReal','LucroPresumido','SimplesNacional','MicroempreendedorIndividual','Isento'} [companies.taxRegime] Company tax regime.
    * @apiSuccess {String} [companies.legalNature] Company legal nature.
    * @apiSuccess {Number} [companies.regionalTaxNumber] State tax number.
    * @apiSuccess {Number} companies.municipalTaxNumber Municipal tax number.
    * @apiSuccess {String} [companies.rpsSerialNumber] Service invoice global RPS Serial number.
    * @apiSuccess {Number} [companies.rpsNumber] Service invoice global RPS number.
    * @apiSuccess {String='None','Active','CityNotSupported','Pending','Inactive'} [companies.fiscalStatus] Fiscal status.
    * @apiSuccess {Object} [companies.certificate] Certificate object.
    * @apiSuccess {String} [companies.certificate.thumbprint] Certificate thumbprint.
    * @apiSuccess {String} [companies.certificate.modifiedOn] Date of modification.
    * @apiSuccess {String} [companies.certificate.expiresOn] Date of expiration.
    * @apiSuccess {String='None','Active','Overdue','Pending'} [companies.certificate.status] Status.
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 200 OK
    *     {
    *        "companies": [
    *          {
    *            "id": "5418cef67d10d930b0361f1b",
    *            "name": "VIVO S.A.",
    *            "tradeName": "",
    *            "federalTaxNumber": 2449992000164,
    *            "email": "",
    *            "address": {
    *              "country": "BRA",
    *              "postalCode": "70073-901",
    *              "street": "Outros Quadra 1 Bloco G Lote 32",
    *              "number": "S/N",
    *              "additionalInformation": "QUADRA 01 BLOCO G",
    *              "district": "Asa Sul",
    *              "city": {
    *                "code": "5300108",
    *                "name": "Brasilia"
    *              },
    *              "state": "DF"
    *            },
    *            "openningDate": "2014-09-10T00:30:59.3348075+00:01",
    *            "taxRegime": "LucroReal",
    *            "legalNature": "SociedadeAnonimaAberta",
    *            "economicActivities": [],
    *            "regionalTaxNumber": 0,
    *            "municipalTaxNumber": 123456789,
    *            "rpsSerialNumber": "IO",
    *            "rpsNumber": 0,
    *            "fiscalStatus": "Active",
    *            "certificate": {
    *              "thumbprint": "01234567891B24F5C23BB39880FC3982279",
    *              "modifiedOn": "2014-12-09T17:21:58.6384682+00:00",
    *              "expiresOn": "2015-12-09T17:17:34+00:00",
    *              "status": "Active"
    *            },
    *            "createdOn": "2014-09-10T00:30:59.3348075+00:00",
    *            "modifiedOn": "2014-12-13T19:04:30.6776431+00:00"
    *          }
    *     ]}   
    *
    */
    [Route("")]
    [HttpGet]
    [ResponseType(typeof(CompanyCollectionResource))]
    public async Task<IHttpActionResult> Get()
    { }

  /**
    * @api {get} companies/:company_id_or_tax_number Get company details
    * @apiName Get
    * @apiGroup Companies
    *
    * @apiUse Unauthorized
    *
    * @apiSuccess {String} company.id The Company unique ID.
    * @apiSuccess {Number} company.federalTaxNumber Federal tax number.
    * @apiSuccess {String} company.name Legal name of company.
    * @apiSuccess {String} [company.tradeName] Trade name of company.
    * @apiSuccess {String} company.email Email of company.    
    * @apiSuccess {Object} company.address The address data.
    * @apiSuccess {String} company.address.country Country code with 3 alpha based on ISO 3166-1 alpha-3.
    * @apiSuccess {String} [company.address.postalCode] Postal code, optional foreign borrowers.
    * @apiSuccess {String} company.address.street The street name.
    * @apiSuccess {String} [company.address.number] The number of address.
    * @apiSuccess {String} [company.address.additionalInformation] Any additional information of address.
    * @apiSuccess {String} [company.address.district] District of address, optional foreign borrowers.
    * @apiSuccess {Object} [company.address.city] The city data.
    * @apiSuccess {Object} [company.address.city.code] City code based on IBGE data.
    * @apiSuccess {Object} [company.address.city.name] City name.
    * @apiSuccess {String} [company.address.state] State abbreviation, optional foreign borrowers.
    * @apiSuccess {String} [company.openningDate] Company openning date.
    * @apiSuccess {String='LucroReal','LucroPresumido','SimplesNacional','MicroempreendedorIndividual','Isento'} [company.taxRegime] Company tax regime.
    * @apiSuccess {String} [company.legalNature] Company legal nature.
    * @apiSuccess {Number} [company.regionalTaxNumber] State tax number.
    * @apiSuccess {Number} company.municipalTaxNumber Municipal tax number.
    * @apiSuccess {String} [company.rpsSerialNumber] Service invoice global RPS Serial number.
    * @apiSuccess {Number} [company.rpsNumber] Service invoice global RPS number.
    * @apiSuccess {String='None','Active','CityNotSupported','Pending','Inactive'} [company.fiscalStatus] Fiscal status.
    * @apiSuccess {Object} [company.certificate] Certificate object.
    * @apiSuccess {String} [company.certificate.thumbprint] Certificate thumbprint.
    * @apiSuccess {String} [company.certificate.modifiedOn] Date of modification.
    * @apiSuccess {String} [company.certificate.expiresOn] Date of expiration.
    * @apiSuccess {String='None','Active','Overdue','Pending'} [company.certificate.status] Status.
    *
    * @apiSuccessExample Success-Response:
    *     HTTP/1.1 200 OK
    *     {
    *        "companies": {
    *            "id": "5418cef67d10d930b0361f1b",
    *            "name": "VIVO S.A.",
    *            "tradeName": "",
    *            "federalTaxNumber": 2449992000164,
    *            "email": "",
    *            "address": {
    *              "country": "BRA",
    *              "postalCode": "70073-901",
    *              "street": "Outros Quadra 1 Bloco G Lote 32",
    *              "number": "S/N",
    *              "additionalInformation": "QUADRA 01 BLOCO G",
    *              "district": "Asa Sul",
    *              "city": {
    *                "code": "5300108",
    *                "name": "Brasilia"
    *              },
    *              "state": "DF"
    *            },
    *            "openningDate": "2014-09-10T00:30:59.3348075+00:01",
    *            "taxRegime": "LucroReal",
    *            "legalNature": "SociedadeAnonimaAberta",
    *            "economicActivities": [],
    *            "regionalTaxNumber": 0,
    *            "municipalTaxNumber": 123456789,
    *            "rpsSerialNumber": "IO",
    *            "rpsNumber": 0,
    *            "fiscalStatus": "Active",
    *            "certificate": {
    *              "thumbprint": "01234567891B24F5C23BB39880FC3982279",
    *              "modifiedOn": "2014-12-09T17:21:58.6384682+00:00",
    *              "expiresOn": "2015-12-09T17:17:34+00:00",
    *              "status": "Active"
    *            },
    *            "createdOn": "2014-09-10T00:30:59.3348075+00:00",
    *            "modifiedOn": "2014-12-13T19:04:30.6776431+00:00"
    *        }
    *     }   
    *
    */
    [Route("{company_id_or_tax_number}")]
    [HttpGet]
    [ResponseType(typeof(CompanySingleResource))]
    public async Task<IHttpActionResult> Get(string company_id_or_tax_number)
    { }

    /// <summary>
    /// Criar uma empresa
    /// </summary>
    /// <param name="item">Dados da empresa</param>
    /// <returns>Todas os detalhes da empresa</returns>
    /// <response code="201">Sucesso na criação da empresa</response>
    /// <response code="400">API Key da conta não é valida</response>
    /// <response code="409">Já existe uma empresa com o CNPJ informado</response>
    [Route("")]
    [HttpPost]
    [ResponseType(typeof(CompanySingleResource))]
    public async Task<IHttpActionResult> Post(CompanyResource item)
    { }

    /// <summary>
    /// Atualizar uma empresa
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <param name="item">Dados da empresa</param>
    /// <returns>Todos os detalhes de uma empresa</returns>
    /// <response code="200">Sucesso na atualização da empresa</response>
    /// <response code="400">API Key da conta não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    [Route("{company_id}")]
    [HttpPut]
    [ResponseType(typeof(CompanySingleResource))]
    public async Task<IHttpActionResult> Put(string company_id, CompanyResource item)
    { }

    /// <summary>
    /// Excluir uma empresa
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <returns>Todos os detalhes de uma empresa</returns>
    /// <response code="200">Sucesso na remoção da empresa</response>
    /// <response code="400">API Key da conta não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    /// <response code="404">empresa não foi encontrada</response>
    [Route("{company_id}")]
    [HttpDelete]
    public async Task<IHttpActionResult> Delete(string company_id)
    { }

    /// <summary>
    /// Upload do certificado digital da empresa usando o codificação multipart/form-data.
    /// </summary>
    /// <param name="company_id">ID da empresa</param>
    /// <returns>Todos os detalhes de uma empresa</returns>
    /// <response code="200">Sucesso na atualização da empresa</response>
    /// <response code="400">API Key da conta não é valida</response>
    /// <response code="400">Algum parametro informado não é válido</response>
    /// <response code="404">Empresa não foi encontrada</response>
    /// <response code="415">Nenhum arquivo foi encontrado na requisição</response>
    [Route("{company_id}/certificate")]
    [HttpPost]
    [ResponseType(typeof(string))]
    public async Task<IHttpActionResult> Post(string company_id)
    { }
}