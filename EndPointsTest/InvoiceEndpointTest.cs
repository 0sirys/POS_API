
using EndPointsTest.Objects.Products;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ShopApi.Controllers;
using ShopApi.DTOs.InvoiceDTOs;
using ShopApi.Interface;

namespace EndPointsTest;

public class InvoiceEndpointTest
{
    [Fact]
    public async void InvoiceAdd()
    {
        InvoiceDTOTest invoiceDTOTest = new();
        IEnumerable<InvoiceDTO> lstout = [invoiceDTOTest.invoiceDTOOtupt];
        // Given
        IService<InvoiceDTO, long> repository = Substitute.For<IService<InvoiceDTO, long>>();
        IGenerator generator = Substitute.For<IGenerator>();
        repository.Add(invoiceDTOTest.invoiceDTOInput).Returns(Task.FromResult(invoiceDTOTest.invoiceDTOOtupt));

        // When
        var controller = new InvoiceController(repository, generator);
        var response = await controller.AddInvoice(invoiceDTOTest.invoiceDTOInput);
        var parse = response.Result.As<OkObjectResult>().Value.As<InvoiceDTO>();
        // Then
        Assert.Equivalent(invoiceDTOTest.invoiceDTOOtupt, parse);
    }



    /*   [Fact]
      public async void Report()
      {
          // Given
          DateTime firstime = new(05 / 2 / 2024);
          InvoiceDTOTest invoiceDTOTest = new();
          IEnumerable<Invoice> lstout = [invoiceDTOTest.reportentity];
          IInvoiceRepository<Invoice> invoiceRepository = Substitute.For<IInvoiceRepository<Invoice>>();
          invoiceRepository.GetMonthInvoice(firstime, DateTime.Today).Returns(Task.FromResult(lstout));

          IInvoice repository = Substitute.For<IInvoice>();
          repository.GetMonthReportService(DateTime.Today).Returns(Task.FromResult(@"C:\Users\CCTV\Documents\ShopApi\Reports"));
          // When
          var controller = new InvoiceController(repository);
          var response = await controller.GetMonthInvoice(DateTime.Today);
          var parse = response.Result.As<OkObjectResult>().Value.As<string>();
          // Then
          Assert.True(String.Compare(parse, @"C:\Users\CCTV\Documents\ShopApi\Reports") == 0);
      }
   */
    [Fact]
    public async void Invoiceget()
    {
        InvoiceDTOTest invoiceDTOTest = new();
        IEnumerable<InvoiceDTO> lstout = [invoiceDTOTest.invoiceDTOOtupt];
        // Given
        IService<InvoiceDTO, long> repository = Substitute.For<IService<InvoiceDTO, long>>();
        IGenerator generator = Substitute.For<IGenerator>();
        repository.Get(invoiceDTOTest.invoiceDTOInput.Code).Returns(Task.FromResult(lstout));

        // When
        var controller = new InvoiceController(repository, generator);
        var response = await controller.GetInvoice(invoiceDTOTest.invoiceDTOInput.Code);
        var parse = response.Result.As<OkObjectResult>().Value.As<IEnumerable<InvoiceDTO>>();
        // Then
        Assert.Equivalent(lstout, parse);
        Assert.Contains(invoiceDTOTest.invoiceDTOOtupt, parse);
    }
}
