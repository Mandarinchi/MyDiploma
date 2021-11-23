create database Electronaya_obuc_programma
use Electronaya_obuc_programma


CREATE TABLE [dbo].[Admin] (
    [Id]       INT           NULL, 
    [Login_admin]      NVARCHAR (10) NULL,
    [Password] NVARCHAR (15) NULL
    
);

CREATE TABLE [dbo].[OKR] (
    [Id]       INT IDENTITY not null, 
    [Sentences]      NVARCHAR (max) NULL,
	[Sentences_for_second_okr]  NVARCHAR (max) NULL,
	[Sentences_for_second_okr_questions]NVARCHAR (max) NULL,
	[Sentences_for_second_okr_answer] bit Null,
	[Sentences_for_second_okr_Name_of_theme_for_questions]NVARCHAR (max) NULL,
    [Sentences_for_second_okr_Name_of_theme]NVARCHAR (max) NULL
);
CREATE TABLE [dbo].[Prepod] (
    [Id]       INT           IDENTITY  NOT NULL, --(1, 1) NOT NULL,
    [FIO]      NVARCHAR (50) NULL,
    [Password] NVARCHAR (10) NULL,
    [Groups]   NVARCHAR (50) NULL,
    CONSTRAINT [CS_PK_Prepod] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Student_profile] (
    [Id]                          INT  IDENTITY  NOT NULL, --(1, 1)    NOT NULL,
    [id_of_student]               INT            NULL,
    [Number_of_group]             NVARCHAR (10)  NULL,
    [id_of_theme]                 INT            NULL,
    [points]                      INT            NULL,
    [spisok_words_which_wrong]    NVARCHAR (MAX) NULL,
    [spisok_words_which_right]    NVARCHAR (MAX) NULL,
    [time_of_restart_Right_words] DATETIME       NULL,
    [time_of_restart_Wrong_words] DATETIME       NULL,
    [count_right_words]           INT            NULL,
	[count_wrong_words]           INT            NULL,
	[count_id_of_theme]           NVARCHAR (MAX) NULL,
	[setter]					  INT			 NULL,
    CONSTRAINT [CS_PK_Id_Of_student] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Rules] (
    [Id]                            INT            IDENTITY NOT NULL, --(1, 1) NOT NULL,
    [Rules]                         NVARCHAR (MAX) NULL,
    [id_of_prepod_rules]            INT            NULL,
   -- [id_of_student_profile_rules]   INT            NULL,
    [string_format_of_rules_number] NVARCHAR (50)  NULL,
    [string_format_of_rules_name]   NVARCHAR (50)  NULL,
    CONSTRAINT [CS_PK_Rules] PRIMARY KEY CLUSTERED ([Id] ASC),
   -- CONSTRAINT [CS_FK_from_profile_student_rules] FOREIGN KEY ([id_of_student_profile_rules]) REFERENCES [dbo].[Student_profile] ([Id]),
    CONSTRAINT [CS_FK_from_Prepod(Rules)] FOREIGN KEY ([id_of_prepod_rules]) REFERENCES [dbo].[Prepod] ([Id])
);


CREATE TABLE [dbo].[Questions_and_Answers] (
    [Id]                              INT            IDENTITY  NOT NULL,
    [Questions]                       NVARCHAR (MAX) NULL,
	[Answers]                      NVARCHAR (MAX) NULL,
    [id_of_rules]                     INT            NULL,
	[ID_of_Questions_and_Answers]     INT            NULL,
  );

CREATE TABLE [dbo].[Table] (
    [Id]                          INT            IDENTITY NOT NULL, --(1, 1) NOT NULL,
    [Words]                       NVARCHAR (MAX) NULL,
    [Translate]                   NVARCHAR (MAX) NULL,
    [ID_of_theme]                 INT            NULL,
	[ID_of_words]                 INT            NULL,
   
    CONSTRAINT [CS_PK_Table] PRIMARY KEY CLUSTERED ([Id] ASC),
  
   CONSTRAINT [CS_FK_from_Table_rules] FOREIGN KEY ([ID_of_theme]) REFERENCES [dbo].[Rules] ([Id]),
  
);

CREATE TABLE [dbo].[User] (
    [Id]              INT            IDENTITY  NOT NULL, --(1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Age]             DATETIME           NULL,
    --[Id_prepod]       INT      foreign key references dbo.[Prepod]([Id]),
    [Id_profile]      INT            NULL,
    [Number_of_Group] NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);


CREATE TABLE [dbo].[Groups] (
    [Id]     INT           IDENTITY NOT NULL, --(1, 1) NOT NULL,
    [Groups] NVARCHAR (10) NULL,
    CONSTRAINT [CS_PK_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);




TRUNCATE TABLE [Rules]
TRUNCATE TABLE [Table]

drop TABLE [Groups]
drop TABLE [User]
drop TABLE [Table]
drop TABLE [Questions_and_Answers]
drop TABLE [Rules]
drop TABLE [Student_profile]
drop TABLE [Prepod]
drop TABLE [Admin]
drop TABLE [OKR]


TRUNCATE TABLE [OKR]
TRUNCATE TABLE [Admin]
TRUNCATE TABLE [Prepod]
TRUNCATE TABLE [Student_profile]
TRUNCATE TABLE [Rules]
TRUNCATE TABLE [Questions_and_Answers]
TRUNCATE TABLE [Table]
TRUNCATE TABLE [User]
TRUNCATE TABLE [Groups]
drop database Electronaya_obuc_programma