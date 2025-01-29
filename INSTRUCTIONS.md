# Execution intructions
If you don't have Sql Server 2022 Express Edition installed, download it via the link and install it on your machine. https://go.microsoft.com/fwlink/?linkid=2215160
Run the program via the IDE, preferably, then open Swagger in the browser http://localhost:5290/swagger/index.html and run the endpoints.
Below is an example payload for testing:
AddSale
{
  "saleNumber": 15,
  "date": "2025-01-28T01:54:50.469Z",
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "branchSaleMade": "123",
  "products": [
    {
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "quantity": 5,
      "unitPrice": 20
    },
    {
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
      "quantity": 2,
      "unitPrice": 10
    }
  ],
  "totalSaleAmount": 120,
  "isActive": true
}

Para executar os testes unitário basta excutar todos os testes dispníveis da aplicação.