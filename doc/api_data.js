define({ "api": [
  {
    "type": "get",
    "url": "v1/companies/:company_id/serviceinvoices",
    "title": "List all Service Invoices",
    "name": "GetAll",
    "group": "ServiceInvoices",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "id",
            "description": "<p>Company unique ID.</p> "
          }
        ]
      }
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "totalResults",
            "description": "<p>Total results of resources.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "totalPages",
            "description": "<p>Total of pages.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "page",
            "description": "<p>Current page number.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "serviceInvoices",
            "description": "<p>List of Service invoices (Array of Objects).</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.id",
            "description": "<p>The Service Invoice unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Issued'",
              "'Cancelled'",
              "'WaitingCalculateTaxes'",
              "'WaitingDefineRpsNumber'",
              "'WaitingSend'",
              "'WaitingSendCancel'",
              "'WaitingReturn'",
              "'WaitingDownload'",
              "'CancelFailed'",
              "'IssueFailed'"
            ],
            "optional": false,
            "field": "serviceInvoices.flowStatus",
            "description": "<p>The status of processing flow.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.provider",
            "description": "<p>Provider of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.id",
            "description": "<p>The Provider unique ID.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.provider.federalTaxNumber",
            "description": "<p>Federal tax number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.name",
            "description": "<p>Legal name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.tradeName",
            "description": "<p>Trade name of company.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.taxRegime",
            "description": "<p>Company tax regime.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.legalNature",
            "description": "<p>Company legal nature.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.provider.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.postalCode",
            "description": "<p>Postal code, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.provider.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.district",
            "description": "<p>District of address, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city",
            "description": "<p>The city data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.provider.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.provider.address.state",
            "description": "<p>State abbreviation, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.borrower",
            "description": "<p>Borrower of services data as in tax registry.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": true,
            "field": "serviceInvoices.borrower.federalTaxNumber",
            "description": "<p>Federal tax number, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.name",
            "description": "<p>Full name of person or legal entity.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.email",
            "description": "<p>Email of borrower to receive the PDF and XML.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": false,
            "field": "serviceInvoices.borrower.address",
            "description": "<p>The address data.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.address.country",
            "description": "<p>Country code with 3 alpha based on ISO 3166-1 alpha-3.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.postalCode",
            "description": "<p>Postal code, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.borrower.address.street",
            "description": "<p>The street name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.number",
            "description": "<p>The number of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.additionalInformation",
            "description": "<p>Any additional information of address.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.district",
            "description": "<p>District of address, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city",
            "description": "<p>The city data, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city.code",
            "description": "<p>City code based on IBGE data.</p> "
          },
          {
            "group": "Success 200",
            "type": "Object",
            "optional": true,
            "field": "serviceInvoices.borrower.address.city.name",
            "description": "<p>City name.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.borrower.address.state",
            "description": "<p>State abbreviation, optional when abroad Brazil.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.batchNumber",
            "description": "<p>Service invoice batch number received from city.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.number",
            "description": "<p>Service invoice number created by the city.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.checkCode",
            "description": "<p>Service invoice check code verification.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'None'",
              "'Created'",
              "'Issued'",
              "'Cancelled'",
              "'Error'"
            ],
            "optional": false,
            "field": "serviceInvoices.status",
            "description": "<p>Invoice status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Rps'",
              "'RpsMista'",
              "'Cupom'"
            ],
            "optional": false,
            "field": "serviceInvoices.rpsType",
            "description": "<p>RPS type.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Normal'",
              "'Cancelled'",
              "'Lost'"
            ],
            "optional": false,
            "field": "serviceInvoices.rpsStatus",
            "description": "<p>RPS status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.rpsSerialNumber",
            "description": "<p>Service invoice RPS Serial number.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "allowedValues": [
              "'Nenhum'",
              "'DentroMunicipio'",
              "'ForaMunicipio'",
              "'Exportacao'",
              "'Isento'",
              "'Imune'",
              "'SuspensoDecisaoJudicial'",
              "'SuspensoProcedimentoAdministrativo'"
            ],
            "optional": false,
            "field": "serviceInvoices.taxationType",
            "description": "<p>RPS status.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.issuedOn",
            "description": "<p>Service invoice issued on date.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.cityServiceCode",
            "description": "<p>City code of the provided service, contact accountant to get the correct code.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": true,
            "field": "serviceInvoices.federalServiceCode",
            "description": "<p>Federal code of the provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.description",
            "description": "<p>Description of provided service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.servicesAmount",
            "description": "<p>Total amount of service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.deductionsAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.discountUnconditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.discountConditionedAmount",
            "description": "<p>Deductions amount on service.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.baseTaxAmount",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.issRate",
            "description": "<p>Tax rate.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.iisTaxAmount",
            "description": "<p>Calculated tax amount.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.irAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.pisAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.cofinsAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.csllAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.inssAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.issAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.othersAmountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.amountWithheld",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "Number",
            "optional": false,
            "field": "serviceInvoices.amountNet",
            "description": "<p>Base amount for tax calculations.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.createdOn",
            "description": "<p>Date and time of creation.</p> "
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "serviceInvoices.modifiedOn",
            "description": "<p>Date and time of last modification.</p> "
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n    {\n        \"totalResults\": 10,\n        \"totalPages\": 1,\n        \"page\": 1,\n        \"serviceInvoices\": [\n         {\n             \"id\": \"54879dec2916f90728a92fd2\",\n             \"flowStatus\": \"Issued\",\n             \"provider\": {\n               \"id\": \"54879dec2916f90728a92fd2\",\n               \"federalTaxNumber\": 18792479000101,\n               \"name\": \"GABRIEL ALEJANDRO DA SILVA MARQUEZ - EPP\",\n               \"tradeName\": \"CONUBE\",\n               \"taxRegime\": \"SimplesNacional\",\n               \"legalNature\": \"Empresario\",\n               \"municipalTaxNumber\": 48177687,\n               \"email\": \"\",\n               \"address\": {\n                 \"country\": \"\",\n                 \"postalCode\": \"05761-280\",\n                 \"street\": \"Rua João Baptista de Camargo\",\n                 \"number\": \"58\",\n                 \"additionalInformation\": \"\",\n                 \"district\": \"Jardim Maria Virginia\",\n                 \"city\": {\n                   \"code\": \"3550308\",\n                   \"name\": \"São Paulo\"\n                 },\n                 \"state\": \"SP\"\n               }\n             },\n             \"borrower\": {\n               \"name\": \"GABRIEL ALEJANDRO DA SILVA MARQUEZ\",\n               \"federalTaxNumber\": 36645999852,\n               \"email\": \"gblmarquez@hotmail.com\",\n               \"address\": {\n                 \"country\": \"BRA\",\n                 \"postalCode\": \"05761280\",\n                 \"street\": \"Rua João Baptista de Camargo\",\n                 \"number\": \"58\",\n                 \"additionalInformation\": \"\",\n                 \"district\": \"Jd Maria Virginia\",\n                 \"city\": {\n                 \"code\": \"3550308\",\n                 \"name\": \"São Paulo\"\n                 },\n                 \"state\": \"SP\"\n               },\n               \"status\": \"Active\",\n               \"type\": \"Nenhum\",\n               \"createdOn\": \"2014-12-10T01:12:12.1602396+00:00\"\n             },\n             \"batchNumber\": 165784958,\n             \"number\": 131,\n             \"checkCode\": \"SBDPCPEY\",\n             \"status\": \"Issued\",\n             \"rpsType\": \"Rps\",\n             \"rpsStatus\": \"Normal\",\n             \"taxationType\": \"Nenhum\",\n             \"issuedOn\": \"2014-12-09T23:12:13.6932436-02:00\",\n             \"rpsSerialNumber\": \"IO\",\n             \"rpsNumber\": 55,\n             \"cityServiceCode\": \"2690\",\n             \"federalServiceCode\": \"1.04\",\n             \"description\": \"TESTE EMISSAO\",\n             \"servicesAmount\": 0.01,\n             \"deductionsAmount\": 0,\n             \"discountUnconditionedAmount\": 0,\n             \"discountConditionedAmount\": 0,\n             \"baseTaxAmount\": 0.01,\n             \"issRate\": 0.02,\n             \"issTaxAmount\": 0.0002,\n             \"irAmountWithheld\": 0,\n             \"pisAmountWithheld\": 0,\n             \"cofinsAmountWithheld\": 0,\n             \"csllAmountWithheld\": 0,\n             \"inssAmountWithheld\": 0,\n             \"issAmountWithheld\": 0,\n             \"othersAmountWithheld\": 0,\n             \"amountWithheld\": 0,\n             \"amountNet\": 0.01,\n             \"createdOn\": \"2014-12-10T01:12:12.1602396+00:00\",\n             \"modifiedOn\": \"2014-12-10T01:13:03.4274719+00:00\"\n         }\n     ]}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./ServiceInvoicesController.cs",
    "groupTitle": "ServiceInvoices"
  }
] });