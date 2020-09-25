# Login-JWT
Um exemplo funcional de Login/SignUp seguro com criptografia de dados SHA256+Salt feito em Angular e .NET( JWT e Entity Framework)

![foto (4)](https://user-images.githubusercontent.com/48391086/94002744-ab47df00-fd70-11ea-9583-e7e2468c40aa.jpg)
![foto (5)](https://user-images.githubusercontent.com/48391086/94002756-b13dc000-fd70-11ea-90e9-36e747641f9e.jpg)

<h1>Como usar?</h1>
<p>Executar o arquivo .sln do clone deste projeto</p>

<h1>Detalhes do projeto</h1>

<h4>Sign In</h4>
<p>
A senha digitada no front é enviada ao back junto com o nome de usuario,e la é encriptada com SHA256 + um salt onde pegamos as 3 primeiras letras do usuario e geramos o hash.
Ocorre uma pesquisa no banco de dados com o usuario onde o nome e o hash(gerado pela senha e já antes armazenada no banco pelo Sign Up) existe, e retorna esse usuario com alguns dados encriptados com JWT na resposta da requisição,e no front-end o usuario é redirecionado a uma pagina que mostra os dados descriptados do JWT da resposta,e se caso nao exista este usuario o login é negado.
</p>

<h4>Sign Up</h4>
<p>
  O nome de usuario e senha é enviado ao back-end, onde ocorre uma pesquisa no banco para que se valide a existencia de algum usuario com o mesmo nome, caso exista é retornado um erro ao front-end informando que ja existe este usuario. Caso não exista esse usuario, a senha digitada é enviada ao back-end junto ao nome, onde a senha é encriptada com SHA256 e o salt, gerando assim a senha para se adicionar ao novo usuario no banco de dados.
</p>
