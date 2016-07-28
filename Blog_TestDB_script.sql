USE [Blog_Test]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Blog_Number] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NULL,
	[Author] [int] NOT NULL,
	[Description] [nvarchar](2048) NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[Blog_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Comment_Number] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[User_Number] [int] NULL,
	[Writes_Number] [int] NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[Comment_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Likes]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[Like_Number] [int] IDENTITY(1,1) NOT NULL,
	[Like] [int] NOT NULL,
	[Write_Number] [int] NULL,
	[Comment_Number] [int] NULL,
 CONSTRAINT [PK_dbo.Likes] PRIMARY KEY CLUSTERED 
(
	[Like_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topics]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Topic_Number] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Topic_Title] [nvarchar](max) NULL,
	[Blog_Number] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED 
(
	[Topic_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_Number] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Last_Name] [nvarchar](256) NULL,
	[Age] [int] NULL,
	[Education] [nvarchar](256) NULL,
	[Mobile_Phone] [int] NULL,
	[Short_Information] [nvarchar](2048) NULL,
	[Facebook_Link] [nvarchar](max) NULL,
	[Vk_Link] [nvarchar](max) NULL,
	[Mail_Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[User_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Writes]    Script Date: 28.07.2016 19:06:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Writes](
	[Write_Number] [int] IDENTITY(1,1) NOT NULL,
	[Topic_Number] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Author] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_dbo.Writes] PRIMARY KEY CLUSTERED 
(
	[Write_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Blog_Number], [Title], [Author], [Description]) VALUES (1, N'Gozhelnix blog', 1, N'Gozhelnix blog descriptions')
SET IDENTITY_INSERT [dbo].[Blogs] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Comment_Number], [Comment], [User_Number], [Writes_Number]) VALUES (1, N'Comment to the first new', 1, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Likes] ON 

INSERT [dbo].[Likes] ([Like_Number], [Like], [Write_Number], [Comment_Number]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[Likes] ([Like_Number], [Like], [Write_Number], [Comment_Number]) VALUES (2, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Likes] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Topic_Number], [Description], [Topic_Title], [Blog_Number]) VALUES (1, N'First topic first first description', N'News', 1)
INSERT [dbo].[Topics] ([Topic_Number], [Description], [Topic_Title], [Blog_Number]) VALUES (2, N'edited description for second topic', N'Writes', 1)
INSERT [dbo].[Topics] ([Topic_Number], [Description], [Topic_Title], [Blog_Number]) VALUES (4, N'Description for third topic', N'Other', 1)
INSERT [dbo].[Topics] ([Topic_Number], [Description], [Topic_Title], [Blog_Number]) VALUES (5, N'Description for fifth topic', N'Articles', 1)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User_Number], [Name], [Last_Name], [Age], [Education], [Mobile_Phone], [Short_Information], [Facebook_Link], [Vk_Link], [Mail_Link]) VALUES (1, N'Tanya', N'Gozhel''na', 18, N'Journalistic', 638366943, N'Student & Journalist', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Writes] ON 

INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (1, 1, N'First new', N'First new with short description', 1, CAST(N'2016-06-27 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (2, 1, N'Second write', N'Description for second write', 1, NULL, NULL)
INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (3, 1, N'Third write', N'Description for third write', 1, NULL, NULL)
INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (4, 1, N'Fourth write', N'The description for fourth write', 1, NULL, NULL)
INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (5, 1, N'Fifth new', N'A description for fifth new', 1, NULL, NULL)
INSERT [dbo].[Writes] ([Write_Number], [Topic_Number], [Title], [Description], [Author], [Date], [Time]) VALUES (6, 1, N'Енеїда', N'Еней був парубок моторний
І хлопець хоть куди козак,
Удавсь на всеє зле проворний,
Завзятійший од всіх бурлак.
Но греки, як спаливши Трою,
Зробили з неї скирту гною,
Він взявши торбу тягу дав;
Забравши деяких троянців,
Осмалених, як гиря, ланців,
П''ятами з Трої накивав.

Він, швидко поробивши човни,
На синє море поспускав,
Троянців насаджавши повні,
І куди очі почухрав.
Но зла Юнона, суча дочка,
Розкудкудакалась, як квочка,
Енея не любила - страх;
Давно вона уже хотіла,
Щоб його душка полетіла
К чортам і щоб і дух не пах.

Еней був тяжко не по серцю
Юноні, - все її гнівив:
Здававсь гірчийший їй від перцю,
Ні в чим Юнони не просив;
Но гірш за те їй не любився,
Що, бачиш, в Трої народився
І мамою Венеру звав;
І що його покійний дядько,
Паріс, Пріамове дитятко,
Путівочку Венері дав.

Побачила Юнона з неба,
Що пан Еней на поромах;
А то шепнула сука Геба...
Юнону взяв великий жах!
Впрягла в гринджолята павичку,
Сховала під кибалку мичку,
Щоб не світилася коса;
Взяла спідницю і шнурівку,
І хліба з сіллю на тарілку,
К Еолу мчалась, як оса.

"Здоров, Еоле, пане-свату!
Ой, як ся маєш, як живеш? -
Сказала, як ввійшла у хату,
Юнона. - Чи гостей ти ждеш?.."
Поставила тарілку з хлібом
Перед старим Еолом-дідом,
Сама же сіла на ослін.
"Будь ласкав, сватоньку-старику!
Ізбий Енея з пантелику,
Тепер пливе на море він.

Ти знаєш, він який суціга,
Паливода і горлоріз;
По світу як іще побіга,
Чиїхсь багацько виллє сліз.
Пошли на його лихо злеє,
Щоб люди всі, що при Енеї,
Послизли і щоб він і сам...
За сеє ж дівку чорнобриву,
Смачную, гарну, уродливу,
Тобі я, далебі, що дам".

"Гай, гай! Ой, дей же його кату!-
Еол насупившись сказав. - 
Я все б зробив за сюю плату,
Та вітри всі порозпускав:
Борей недуж лежить з похмілля,
А Нот поїхав на весілля,
Зефір же, давній негодяй,
З дівчатами заженихався,
А Евр в поденщики найнявся, -
Як хочеш, так і помишляй!

Та вже для тебе обіщаюсь
Енеєві я ляпас дать;
Я хутко, миттю постараюсь
В трістя його к чортам загнать.
Прощай же! Швидше убирайся,
Обіцянки не забувайся,
Бо послі, чуєш, нічичирк!
Як збрешеш, то хоча надсядься,
На ласку послі не понадься,
Тогді від мене возьмеш чвирк".

Еол, оставшись на господі,
Зобрав всіх вітрів до двора,
Велів поганій буть погоді...
Якраз на морі і гора!
Все море зараз спузирило,
Водою мов в ключи забило,
Еней тут крикнув, як на пуп;
Заплакався і заридався,
Пошарпався, увесь подрався,
На тім''ї начесав аж струп.

Прокляті вітри роздулися,
А море з лиха аж реве;
Слізьми троянці облилися,
Енея за живіт бере;
Всі човники їх розчухрало,
Багацько війська тут пропало;
Тогді набрались всі сто лих!
Еней кричіть, що "я Нептуну
Півкопи грошей в руку суну,
Аби на морі штурм утих".

Нептун іздавна був дряпічка,
Почув Енеїв голосок;
Шатнувся зараз із запічка,
Півкопи для його кусок!..
І миттю осідлавши рака,
Схвативсь на його, мов бурлака,
І вирнув з моря як карась.
Загомонів на вітрів грізно:
"Чого ви гудете так грізно?
До моря, знаєте, вам зась!"

От тут-то вітри схаменулись
І ну всі драла до нори;
До ляса, мов ляхи, шатнулись,
Або од їжака тхори.
Нептун же зараз взяв мітелку
І вимів море як світелку,
То сонце глянуло на світ.
Еней тогді як народився,
Разів із п''ять перехрестився,
Звелів готовити обід.

Поклали шальовки соснові,
Кругом наставили мисок;
І страву всякую, без мови,
В голодний пхали все куток.
Тут з салом галушки лигали,
Лемішку і куліш глитали
І брагу кухликом тягли;
Та і горілочку хлистали, --
Насилу із-за столу встали
І спати послі всі лягли.

Венера, не послідня шльоха,
Проворна, враг її не взяв,
Побачила, що так полоха
Еол синка, що аж захляв;
Умилася, причепурилась
І, як в неділю, нарядилась,
Хоть би до дудки на танець!
Взяла очіпок грезетовий
І кунтуш з усами люстровий,
Пішла к Зевесу на ралець.

Зевес тогді кружав сивуху
І оселедцем заїдав;
Він, сьому випивши восьмуху,
Послідки з кварти виливав.
Прийшла Венера, іскривившись.
Заплакалась и завіскрившись,
І стала хлипать перед ним:
"Чим пред тобою, милий тату,
Син заслужив таку мій плату?
Ійон, мов в свинки грають їм.

Куди йому уже до Риму?
Хіба як здохне чорт в рові!
Як вернеться пан хан до Криму,
Як женитсья сич на сові.
Хіба б уже та не Юнона,
Щоб не вказала макогона,
Що й досі слухає чмелів!
Коли б вона та не бісилась,
Замовкла і не комизилась,
Щоб ти се сам їй ізвелів".

Юпітер, все допивши з кубка,
Погладив свій рукою чуб:
"Ох, доцю, ти моя голубка!
Я в правді твердий так, як дуб.
Еней збудує сильне царство
І заведе своє там панство:
Не малий буде він панок.
На панщину ввесь світ погонить,
Багацько хлопців там наплодить
І всім їм буде ватажок.

Заїде до Дідони в гості
І буде там бенкетовать;
Полюбиться її він мосці
І буде бісики пускать.
Іди, небого, не журися,
Попонеділкуй, помолися,
Все буде так, як я сказав".
Венера низько поклонилась
І з панотцем своїм простилась,
А він її поціловав.

Еней прочумався, проспався
І голодранців позбирав,
Зовсім зібрався і уклався,
І, скілько видно, почухрав.
Плив-плив, плив-плив, що аж обридло,
І море так йому огидло,
Що бісом на його дививсь:
"Коли б, -- каже, -- умер я в Трої,
Уже б не пив сеї гіркої
І марне так не волочивсь".

Потім, до берега приставши
З троянством голим всім своїм,
На землю з човнів повстававши,
Спитавсь, чи є що їсти їм.
І зараз чогось попоїли,
Щоб на путі не ослабіли;
Пішли, куди хто запопав.
Еней по берегу попхався
І сам не знав, куди слонявся,
Аж гульк -- і в город причвалав.Еней був парубок моторний
І хлопець хоть куди козак,
Удавсь на всеє зле проворний,
Завзятійший од всіх бурлак.
Но греки, як спаливши Трою,
Зробили з неї скирту гною,
Він взявши торбу тягу дав;
Забравши деяких троянців,
Осмалених, як гиря, ланців,
П''ятами з Трої накивав.

Він, швидко поробивши човни,
На синє море поспускав,
Троянців насаджавши повні,
І куди очі почухрав.
Но зла Юнона, суча дочка,
Розкудкудакалась, як квочка,
Енея не любила - страх;
Давно вона уже хотіла,
Щоб його душка полетіла
К чортам і щоб і дух не пах.

Еней був тяжко не по серцю
Юноні, - все її гнівив:
Здававсь гірчийший їй від перцю,
Ні в чим Юнони не просив;
Но гірш за те їй не любився,
Що, бачиш, в Трої народився
І мамою Венеру звав;
І що його покійний дядько,
Паріс, Пріамове дитятко,
Путівочку Венері дав.

Побачила Юнона з неба,
Що пан Еней на поромах;
А то шепнула сука Геба...
Юнону взяв великий жах!
Впрягла в гринджолята павичку,
Сховала під кибалку мичку,
Щоб не світилася коса;
Взяла спідницю і шнурівку,
І хліба з сіллю на тарілку,
К Еолу мчалась, як оса.

"Здоров, Еоле, пане-свату!
Ой, як ся маєш, як живеш? -
Сказала, як ввійшла у хату,
Юнона. - Чи гостей ти ждеш?.."
Поставила тарілку з хлібом
Перед старим Еолом-дідом,
Сама же сіла на ослін.
"Будь ласкав, сватоньку-старику!
Ізбий Енея з пантелику,
Тепер пливе на море він.

Ти знаєш, він який суціга,
Паливода і горлоріз;
По світу як іще побіга,
Чиїхсь багацько виллє сліз.
Пошли на його лихо злеє,
Щоб люди всі, що при Енеї,
Послизли і щоб він і сам...
За сеє ж дівку чорнобриву,
Смачную, гарну, уродливу,
Тобі я, далебі, що дам".

"Гай, гай! Ой, дей же його кату!-
Еол насупившись сказав. - 
Я все б зробив за сюю плату,
Та вітри всі порозпускав:
Борей недуж лежить з похмілля,
А Нот поїхав на весілля,
Зефір же, давній негодяй,
З дівчатами заженихався,
А Евр в поденщики найнявся, -
Як хочеш, так і помишляй!

Та вже для тебе обіщаюсь
Енеєві я ляпас дать;
Я хутко, миттю постараюсь
В трістя його к чортам загнать.
Прощай же! Швидше убирайся,
Обіцянки не забувайся,
Бо послі, чуєш, нічичирк!
Як збрешеш, то хоча надсядься,
На ласку послі не понадься,
Тогді від мене возьмеш чвирк".

Еол, оставшись на господі,
Зобрав всіх вітрів до двора,
Велів поганій буть погоді...
Якраз на морі і гора!
Все море зараз спузирило,
Водою мов в ключи забило,
Еней тут крикнув, як на пуп;
Заплакався і заридався,
Пошарпався, увесь подрався,
На тім''ї начесав аж струп.

Прокляті вітри роздулися,
А море з лиха аж реве;
Слізьми троянці облилися,
Енея за живіт бере;
Всі човники їх розчухрало,
Багацько війська тут пропало;
Тогді набрались всі сто лих!
Еней кричіть, що "я Нептуну
Півкопи грошей в руку суну,
Аби на морі штурм утих".

Нептун іздавна був дряпічка,
Почув Енеїв голосок;
Шатнувся зараз із запічка,
Півкопи для його кусок!..
І миттю осідлавши рака,
Схвативсь на його, мов бурлака,
І вирнув з моря як карась.
Загомонів на вітрів грізно:
"Чого ви гудете так грізно?
До моря, знаєте, вам зась!"

От тут-то вітри схаменулись
І ну всі драла до нори;
До ляса, мов ляхи, шатнулись,
Або од їжака тхори.
Нептун же зараз взяв мітелку
І вимів море як світелку,
То сонце глянуло на світ.
Еней тогді як народився,
Разів із п''ять перехрестився,
Звелів готовити обід.

Поклали шальовки соснові,
Кругом наставили мисок;
І страву всякую, без мови,
В голодний пхали все куток.
Тут з салом галушки лигали,
Лемішку і куліш глитали
І брагу кухликом тягли;
Та і горілочку хлистали, --
Насилу із-за столу встали
І спати послі всі лягли.

Венера, не послідня шльоха,
Проворна, враг її не взяв,
Побачила, що так полоха
Еол синка, що аж захляв;
Умилася, причепурилась
І, як в неділю, нарядилась,
Хоть би до дудки на танець!
Взяла очіпок грезетовий
І кунтуш з усами люстровий,
Пішла к Зевесу на ралець.

Зевес тогді кружав сивуху
І оселедцем заїдав;
Він, сьому випивши восьмуху,
Послідки з кварти виливав.
Прийшла Венера, іскривившись.
Заплакалась и завіскрившись,
І стала хлипать перед ним:
"Чим пред тобою, милий тату,
Син заслужив таку мій плату?
Ійон, мов в свинки грають їм.

Куди йому уже до Риму?
Хіба як здохне чорт в рові!
Як вернеться пан хан до Криму,
Як женитсья сич на сові.
Хіба б уже та не Юнона,
Щоб не вказала макогона,
Що й досі слухає чмелів!
Коли б вона та не бісилась,
Замовкла і не комизилась,
Щоб ти се сам їй ізвелів".

Юпітер, все допивши з кубка,
Погладив свій рукою чуб:
"Ох, доцю, ти моя голубка!
Я в правді твердий так, як дуб.
Еней збудує сильне царство
І заведе своє там панство:
Не малий буде він панок.
На панщину ввесь світ погонить,
Багацько хлопців там наплодить
І всім їм буде ватажок.

Заїде до Дідони в гості
І буде там бенкетовать;
Полюбиться її він мосці
І буде бісики пускать.
Іди, небого, не журися,
Попонеділкуй, помолися,
Все буде так, як я сказав".
Венера низько поклонилась
І з панотцем своїм простилась,
А він її поціловав.

Еней прочумався, проспався
І голодранців позбирав,
Зовсім зібрався і уклався,
І, скілько видно, почухрав.
Плив-плив, плив-плив, що аж обридло,
І море так йому огидло,
Що бісом на його дививсь:
"Коли б, -- каже, -- умер я в Трої,
Уже б не пив сеї гіркої
І марне так не волочивсь".

Потім, до берега приставши
З троянством голим всім своїм,
На землю з човнів повстававши,
Спитавсь, чи є що їсти їм.
І зараз чогось попоїли,
Щоб на путі не ослабіли;
Пішли, куди хто запопав.
Еней по берегу попхався
І сам не знав, куди слонявся,
Аж гульк -- і в город причвалав.', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Writes] OFF
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Comments_Comment_Number] FOREIGN KEY([Comment_Number])
REFERENCES [dbo].[Comments] ([Comment_Number])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Comments_Comment_Number]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Writes_Write_Number] FOREIGN KEY([Write_Number])
REFERENCES [dbo].[Writes] ([Write_Number])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Writes_Write_Number]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Topics_dbo.Blogs_Blog_Number] FOREIGN KEY([Blog_Number])
REFERENCES [dbo].[Blogs] ([Blog_Number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_dbo.Topics_dbo.Blogs_Blog_Number]
GO
ALTER TABLE [dbo].[Writes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Writes_dbo.Topics_Topic_Number] FOREIGN KEY([Topic_Number])
REFERENCES [dbo].[Topics] ([Topic_Number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Writes] CHECK CONSTRAINT [FK_dbo.Writes_dbo.Topics_Topic_Number]
GO
