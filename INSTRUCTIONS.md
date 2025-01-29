# Execution intructions
Caso não possua o Sql Server 2022 Express Edition instalado, faça o download pelo link e instale em sua máquina. https://go.microsoft.com/fwlink/?linkid=2215160
Execute o programa pelo o IDE de prefrência, logo após abra o Swagger no navegador http://localhost:5290/swagger/index.html e execute os endpoints.
Segue exemplo de payload para teste :
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