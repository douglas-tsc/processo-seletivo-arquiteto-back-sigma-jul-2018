# **Processo Seletivo Arquiteto de Software Back-End da Sigma/TJMT**

### **Bem-vindo ao processo seletivo para arquiteto de software da Sigma/TJMT!**

## **O desafio**

### **Crie serviços REST com Web API para o gerenciamento de patrimônios de uma empresa.**


## **A Solução**

Neste projeto tive uma preocupação com a manutenibilidade a longo prazo, por isso adotei apenas padrões de arquitetura já consistentes e bem aceitos pela comunidade, com uma leve curva de aprendizado e com pouco tempo qualquer desenvolvedor com conhecimento mínimo de orientação a objetos se familiariza e consegue dar continuidade.

Na solução foi aplicada a metodologia Code First, centrada em classes POCO, para desenvolvimento da camada de acesso a dados.
Farei uso também do Entity Framework para obter o máximo de produtividade e os dados serão persistidos em um base de dados SQL Server v17.

Projetado com relação ao design dirigido por domínio (DDD), o Design Pattern Repository foi adotado para criar uma camada de abstração entre o modelo de domínio e as regras de negócio e facilitar os testes de unidade (TDD) da Api.


### **Requisitos técnicos**

* .NET Core 2 API RESTful

* Testes com xUnit e Moq

* Documentação com Swagger


### **Recursos que faltaram ser implementados**

* JWT para Autenticação do Swagger