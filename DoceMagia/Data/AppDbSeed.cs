using DoceMagia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GCook.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular Perfil
        List<IdentityRole> roles = new()
        {
            new()
            {
                Id = "36f25c22-38d8-4be6-af11-5a709cf16bc9",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new()
            {
                Id = "a20c3739-5650-4cab-8a8f-d6cec2b151be",
                Name = "Moderador",
                NormalizedName = "MODERADOR"
            },
            new()
            {
                Id = "1ce68b46-785b-4d5e-9d5e-525554915d46",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Popular Usuários
        List<Usuario> usuarios = new()
        {
            new()
            {
                Id = "36f272b6-fbde-41b5-9b85-2d3661567ccf",
                Nome = "ADMINISTRADOR",
                UserName = "administrador@docemagia.com",
                NormalizedUserName = "ADMINISTRADOR@DOCEMAGIA.COM",
                Email = "administrador@docemagia.com",
                NormalizedEmail = "ADMINISTRADOR@DOCEMAGIA.COM",
                DataNascimento = DateTime.Parse("08/05/2008"),
                Foto = "/img/usuarios/0cbf5d2b-b2d5-4b06-bb4d-3b353b10e2b0.png",
                EmailConfirmed = true,
                LockoutEnabled = false
            },
            new()
            {
                Id = "0cbf5d2b-b2d5-4b06-bb4d-3b353b10e2b0",
                Nome = "Medelen Victória de Oliveira Lima",
                UserName = "medelenvictoria7@gmail.com",
                NormalizedUserName = "MEDELENVICTORIA7@GMAIL.COM",
                Email = "medelenvictoria7@gmail.com",
                NormalizedEmail = "MEDELENVICTORIA7@GMAIL.COM",
                DataNascimento = DateTime.Parse("08/05/2008"),
                Foto = "/img/usuarios/0cbf5d2b-b2d5-4b06-bb4d-3b353b10e2b0.png",
                EmailConfirmed = true,
                LockoutEnabled = true
            },
        };
        foreach (var usuario in usuarios)
        {
            PasswordHasher<IdentityUser> passwordHasher = new();
            usuario.PasswordHash = passwordHasher.HashPassword(usuario, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Popular Perfil Usuário
        List<IdentityUserRole<string>> userRoles = new()
        {
            new()
            {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new()
            {
                UserId = usuarios[1].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular Categoria
        List<Categoria> categorias = new()
        {
            new()
            {
                Id = 1,
                Nome = "Bolos",
                Icone = "fas fa-cake-candles",
            },
            new()
            {
                Id = 2,
                Nome = "Cupcakes",
                Icone = "fas fa-birthday-cake",
            },
            new()
            {
                Id = 3,
                Nome = "Doces Tradicionais",
                Icone = "fas fa-candy-cane",
            },
            new()
            {
                Id = 4,
                Nome = "Doces Gourmet",
                Icone = "fas fa-cookie",
            },
            new()
            {
                Id = 5,
                Nome = "Bombons e Trufas",
                Icone = "icon-candy"
            },
            new()
            {
                Id = 6,
                Nome = "Sobremesas",
                Icone = "fas fa-ice-cream",
            },
            new()
            {
                Id = 7,
                Nome = "Doces no Pote",
                Icone = "fas fa-jar",
            },
            new()
            {
                Id = 8,
                Nome = "Doces para Festa",
                Icone = "fas fa-gift",

            }
        };
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region Popular Ingredientes
        List<Ingrediente> ingredientes = new() {
        new Ingrediente() {
            Id = 1,
            Nome = "Farinha de Trigo"
        },
        new Ingrediente() {
            Id = 2,
            Nome = "Açúcar"
        },
        new Ingrediente() {
            Id = 3,
            Nome = "Leite"
        },
        new Ingrediente() {
            Id = 4,
            Nome = "Ovos"
        },
        new Ingrediente() {
            Id = 5,
            Nome = "Manteiga"
        },
        new Ingrediente() {
            Id = 6,
            Nome = "Chocolate"
        },
        new Ingrediente() {
            Id = 7,
            Nome = "Cacau em Pó"
        },
        new Ingrediente() {
            Id = 8,
            Nome = "Leite Condensado"
        },
        new Ingrediente() {
            Id = 9,
            Nome = "Creme de Leite"
        },
        new Ingrediente() {
            Id = 10,
            Nome = "Fermento em Pó"
        },
        new Ingrediente() {
            Id = 11,
            Nome = "Baunilha"
        },
        new Ingrediente() {
            Id = 12,
            Nome = "Morango"
        },
        new Ingrediente() {
            Id = 13,
            Nome = "Granulado"
        },
        new Ingrediente() {
            Id = 14,
            Nome = "Coco Ralado"
        }
        };
        builder.Entity<Ingrediente>().HasData(ingredientes);
        #endregion

        #region Populate Receita
        List<Receita> receitas = new() {
            new Receita() {
                Id = 1,
                Nome = "Brigadeiro",
                Descricao = "Clássico doce brasileiro feito com leite condensado, chocolate e manteiga, finalizado com granulado.",
                CategoriaId = 3,
                Dificuldade = Dificuldade.Fácil,
                Rendimento = 20,
                TempoPreparo = "20 minutos",
                Foto = "/img/receitas/1.jpg",
                UsuarioId = usuarios[0].Id,
            },
            new Receita() {
                Id = 2,
                Nome = "Bolo de Chocolate",
                Descricao = "Bolo macio de chocolate, perfeito para sobremesas ou aniversários.",
                CategoriaId = 1,
                Dificuldade = Dificuldade.Médio,
                Rendimento = 10,
                TempoPreparo = "50 minutos",
                Foto = "/img/receitas/2.webp",
                UsuarioId = usuarios[0].Id,
            },
            new Receita() {
                Id = 3,
                Nome = "Cupcake de Baunilha",
                Descricao = "Cupcakes leves e fofinhos com sabor suave de baunilha.",
                CategoriaId = 2,
                Dificuldade = Dificuldade.Fácil,
                Rendimento = 12,
                TempoPreparo = "40 minutos",
                Foto = "/img/receitas/3.png",
                UsuarioId = usuarios[0].Id,
            },
            new Receita() {
                Id = 4,
                Nome = "Bombom de Morango",
                Descricao = "Morango fresco envolvido em brigadeiro branco e coberto com chocolate, perfeito para festas e ocasiões especiais.",
                CategoriaId = 5,
                Dificuldade = Dificuldade.Difícil,
                Rendimento = 12,
                TempoPreparo = "60 minutos",
                Foto = "/img/receitas/4.jpg",
                UsuarioId = usuarios[0].Id,
            },
        };
        builder.Entity<Receita>().HasData(receitas);
        #endregion

        #region Popular Preparo
        List<Preparo> preparos = new()
        {
        new()
        {
            Id = 1,
            ReceitaId = 1,
            Texto = "Separe os ingredientes: leite condensado, chocolate em pó, manteiga e granulado para finalizar."
        },
        new()
        {
            Id = 2,
            ReceitaId = 1,
            Texto = "Em uma panela, coloque o leite condensado, o chocolate em pó e a manteiga."
        },
        new()
        {
            Id = 3,
            ReceitaId = 1,
            Texto = "Leve ao fogo baixo, mexendo sempre para evitar que grude no fundo da panela."
        },
        new()
        {
            Id = 4,
            ReceitaId = 1,
            Texto = "Continue mexendo até a mistura engrossar e começar a desgrudar do fundo da panela."
        },
        new()
        {
            Id = 5,
            ReceitaId = 1,
            Texto = "Desligue o fogo e transfira o brigadeiro para um prato untado com manteiga."
        },
        new()
        {
            Id = 6,
            ReceitaId = 1,
            Texto = "Deixe esfriar por alguns minutos até que seja possível manusear a massa."
        },
        new()
        {
            Id = 7,
            ReceitaId = 1,
            Texto = "Enrole pequenas porções em formato de bolinha e passe no granulado para finalizar."
        },

            new()
        {
            Id = 8,
            ReceitaId = 2,
            Texto = "Separe os ingredientes: farinha de trigo, açúcar, ovos, chocolate em pó, leite e fermento."
        },
        new()
        {
            Id = 9,
            ReceitaId = 2,
            Texto = "Em uma tigela, misture os ovos, o açúcar e a manteiga."
        },
        new()
        {
            Id = 10,
            ReceitaId = 2,
            Texto = "Adicione o leite, o chocolate em pó e a farinha de trigo."
        },
        new()
        {
            Id = 11,
            ReceitaId = 2,
            Texto = "Acrescente o fermento e mexa delicadamente."
        },
        new()
        {
            Id = 12,
            ReceitaId = 2,
            Texto = "Despeje a massa em uma forma untada e leve ao forno a 180°C por cerca de 40 minutos."
        },
        new()
        {
            Id = 13,
            ReceitaId = 2,
            Texto = "Para a cobertura, coloque em uma panela o creme de leite, o chocolate e o açúcar."
        },
        new()
        {
            Id = 14,
            ReceitaId = 2,
            Texto = "Leve ao fogo baixo mexendo até o chocolate derreter e formar um creme liso."
        },
        new()
        {
            Id = 15,
            ReceitaId = 2,
            Texto = "Despeje a cobertura sobre o bolo já frio e espalhe bem com uma colher."
        },

        new()
        {
            Id = 16,
            ReceitaId = 3,
            Texto = "Separe os ingredientes: farinha de trigo, açúcar, ovos, manteiga, leite e baunilha."
        },
        new()
        {
            Id = 17,
            ReceitaId = 3,
            Texto = "Misture os ovos, o açúcar e a manteiga até formar um creme."
        },
        new()
        {
            Id = 18,
            ReceitaId = 3,
            Texto = "Adicione o leite, a baunilha e a farinha de trigo."
        },
        new()
        {
            Id = 19,
            ReceitaId = 3,
            Texto = "Acrescente o fermento e misture delicadamente."
        },
        new()
        {
            Id = 20,
            ReceitaId = 3,
            Texto = "Distribua a massa nas forminhas e leve ao forno a 180°C por cerca de 25 minutos."
        },
        new()
        {
            Id = 21,
            ReceitaId = 3,
            Texto = "Para a cobertura, misture manteiga, açúcar e algumas gotas de baunilha até formar um creme."
        },
        new()
        {
            Id = 22,
            ReceitaId = 3,
            Texto = "Bata a mistura até ficar leve e cremosa."
        },
        new()
        {
            Id = 23,
            ReceitaId = 3,
            Texto = "Coloque o creme em um saco de confeitar e decore os cupcakes já frios, o granulado é opcional mas faz um charme!!"
        },
        new()
        {
            Id = 24,
            ReceitaId = 4,
            Texto = "Lave bem os morangos e seque completamente com papel toalha."
        },
        new()
        {
            Id = 25,
            ReceitaId = 4,
            Texto = "Em uma panela, coloque o leite condensado e a manteiga para preparar um brigadeiro branco."
        },
        new()
        {
            Id = 26,
            ReceitaId = 4,
            Texto = "Cozinhe em fogo baixo mexendo sempre até desgrudar do fundo da panela."
        },
        new()
        {
            Id = 27,
            ReceitaId = 4,
            Texto = "Deixe o brigadeiro esfriar completamente antes de usar."
        },
        new()
        {
            Id = 28,
            ReceitaId = 4,
            Texto = "Pegue uma pequena porção do brigadeiro e envolva cada morango formando uma bolinha."
        },
        new()
        {
            Id = 29,
            ReceitaId = 4,
            Texto = "Derreta o chocolate em banho-maria ou no micro-ondas."
        },
        new()
        {
            Id = 30,
            ReceitaId = 4,
            Texto = "Mergulhe os bombons no chocolate derretido e coloque sobre papel manteiga."
        },
        new()
        {
            Id = 31,
            ReceitaId = 4,
            Texto = "Leve à geladeira por alguns minutos até o chocolate endurecer."
        },

        };
        builder.Entity<Preparo>().HasData(preparos);
        #endregion

        #region Receita Ingrediente
        List<ReceitaIngrediente> receitaIngredientes = new() {
        // brigadeiro
        new ReceitaIngrediente() {
            ReceitaId = 1,
            IngredienteId = 8,
            Quantidade = "1 lata"
        },
        new ReceitaIngrediente() {
            ReceitaId = 1,
            IngredienteId = 6,
            Quantidade = "3 colheres de sopa"
        },
        new ReceitaIngrediente() {
            ReceitaId = 1,
            IngredienteId = 5,
            Quantidade = "1 colher de sopa"
        },
        new ReceitaIngrediente() {
            ReceitaId = 1,
            IngredienteId = 13,
            Quantidade = "A gosto"
        },

        // BOLO DE CHOCOLATE
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 1,
            Quantidade = "2 xícaras"
        },
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 2,
            Quantidade = "1 xícara"
        },
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 4,
            Quantidade = "3 unidades"
        },
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 7,
            Quantidade = "1 xícara"
        },
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 3,
            Quantidade = "1 xícara"
        },
        new ReceitaIngrediente() {
            ReceitaId = 2,
            IngredienteId = 10,
            Quantidade = "1 colher de sopa"
        },

        // CUPCAKE
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 1,
            Quantidade = "1 e 1/2 xícara"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 2,
            Quantidade = "1 xícara"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 4,
            Quantidade = "2 unidades"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 5,
            Quantidade = "2 colheres de sopa"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 3,
            Quantidade = "1/2 xícara"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 11,
            Quantidade = "1 colher de chá"
            },
        new ReceitaIngrediente() {
            ReceitaId = 3,
            IngredienteId = 10,
            Quantidade = "1 colher de chá"
            },

         // Bombom de morango
        new ReceitaIngrediente() { 
            ReceitaId = 4, 
            IngredienteId = 12, 
            Quantidade = "12 unidades" 
            }, // morango
        new ReceitaIngrediente() { 
            ReceitaId = 4, 
            IngredienteId = 8,
            Quantidade = "1 lata"
            }, // leite condensado
        new ReceitaIngrediente() { 
            ReceitaId = 4, 
            IngredienteId = 5, 
            Quantidade = "1 colher de sopa" 
            }, // manteiga
        new ReceitaIngrediente() { 
            ReceitaId = 4, 
            IngredienteId = 6, 
            Quantidade = "300g" 
            }, // chocolate
};
        builder.Entity<ReceitaIngrediente>().HasData(receitaIngredientes);
        #endregion
    }
}

