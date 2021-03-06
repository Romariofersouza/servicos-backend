USE [servicos]
GO
/****** Object:  Table [dbo].[atendimento]    Script Date: 14/03/2022 20:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[atendimento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [text] NOT NULL,
	[data_hora] [timestamp] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_profissional] [int] NOT NULL,
 CONSTRAINT [PK_atendimento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 14/03/2022 20:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](11) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[id_endereco] [int] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_cpf_cliente] UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[endereco]    Script Date: 14/03/2022 20:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[endereco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rua] [varchar](30) NOT NULL,
	[bairro] [varchar](30) NOT NULL,
	[cidade] [varchar](30) NOT NULL,
	[cep] [varchar](8) NOT NULL,
	[complemento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_endereco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profissional]    Script Date: 14/03/2022 20:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profissional](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](11) NOT NULL,
	[cnpj] [varchar](14) NULL,
	[nome] [varchar](50) NOT NULL,
	[id_endereco] [int] NOT NULL,
 CONSTRAINT [PK_profissional] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_cnpj] UNIQUE NONCLUSTERED 
(
	[cnpj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_cpf] UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[telefone]    Script Date: 14/03/2022 20:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[telefone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](11) NOT NULL,
	[id_profissional] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
 CONSTRAINT [PK_telefone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_numero] UNIQUE NONCLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[atendimento]  WITH CHECK ADD  CONSTRAINT [FK_atendimento_atendimento] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[atendimento] CHECK CONSTRAINT [FK_atendimento_atendimento]
GO
ALTER TABLE [dbo].[atendimento]  WITH CHECK ADD  CONSTRAINT [FK_atendimento_profissional] FOREIGN KEY([id_profissional])
REFERENCES [dbo].[profissional] ([id])
GO
ALTER TABLE [dbo].[atendimento] CHECK CONSTRAINT [FK_atendimento_profissional]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_endereco] FOREIGN KEY([id_endereco])
REFERENCES [dbo].[endereco] ([id])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_endereco]
GO
ALTER TABLE [dbo].[profissional]  WITH CHECK ADD  CONSTRAINT [FK_profissional_endereco] FOREIGN KEY([id_endereco])
REFERENCES [dbo].[endereco] ([id])
GO
ALTER TABLE [dbo].[profissional] CHECK CONSTRAINT [FK_profissional_endereco]
GO
ALTER TABLE [dbo].[telefone]  WITH CHECK ADD  CONSTRAINT [FK_telefone_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[telefone] CHECK CONSTRAINT [FK_telefone_cliente]
GO
ALTER TABLE [dbo].[telefone]  WITH CHECK ADD  CONSTRAINT [FK_telefone_profissional] FOREIGN KEY([id_profissional])
REFERENCES [dbo].[profissional] ([id])
GO
ALTER TABLE [dbo].[telefone] CHECK CONSTRAINT [FK_telefone_profissional]
GO
