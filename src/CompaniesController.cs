/// <summary>
/// Empresas
/// </summary>
[Authorize]
[RoutePrefix("v1/companies")]
public class CompaniesController
{
    /// <summary>
    /// Listar as empresas ativas de uma conta
    /// </summary>
    /// <returns>Todas as empresas</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da conta não é valida</response>
    [Route("")]
    [HttpGet]
    [ResponseType(typeof(CompanyCollectionResource))]
    public async Task<IHttpActionResult> Get()
    { }

    /// <summary>
    /// Obter os detalhes de uma empresa
    /// </summary>
    /// <param name="company_id_or_tax_number">ID da empresa ou Inscrição Federal (CNPJ)</param>
    /// <returns>Todas os detalhes da empresa</returns>
    /// <response code="200">Sucesso na requisição</response>
    /// <response code="400">API Key da conta não é valida</response>
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