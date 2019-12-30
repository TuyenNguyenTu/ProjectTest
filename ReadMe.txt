CREATE Database ProjectChuyenDe_5
GO
USE [ProjectChuyenDe_5]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AboutMes]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutMes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[Introduce] [ntext] NOT NULL,
	[Image] [nvarchar](500) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Status] [bit] NOT NULL,
	[Note] [ntext] NULL,
 CONSTRAINT [PK_AboutMes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[Avartar] [nvarchar](500) NULL,
	[DisplayName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsAdmin] [bit] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryPosts]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryPosts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[MetaTitle] [nvarchar](50) NULL,
	[MetaKeyword] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_CategoryPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Contents] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedBacks]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeedBacks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [varchar](12) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Contents] [nvarchar](500) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_FeedBacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Footers]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Contents] [ntext] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Footers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[TypeID] [bigint] NOT NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[HinhAnh] [nvarchar](500) NULL,
	[ContentPost] [ntext] NOT NULL,
	[MetaTitle] [nchar](500) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](250) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[ViewCount] [bigint] NULL,
	[Status] [bit] NULL,
	[CategoryId] [bigint] NOT NULL,
	[Note] [ntext] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slides]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slides](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Slides] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeMenus]    Script Date: 12/29/2019 10:35:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeMenus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191129104930_InitialCreate', N'2.1.14-servicing-32113')
SET IDENTITY_INSERT [dbo].[AboutMes] ON 

INSERT [dbo].[AboutMes] ([Id], [FirstName], [LastName], [Title], [MetaTitle], [Introduce], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [Status], [Note]) VALUES (7, N'Nguyễn ', N'Tự Tuyên', N'Tuyên Đẹp trai', N'tuyen-dep-trai', N'<p><strong>ASP.NET Core</strong>&nbsp;là một framework mã nguồn mở, hiệu suất cao và đa nền tảng dùng để xây dựng các ứng dụng hiện đại có kết nối với&nbsp;<a href="https://www.dammio.com/glossary/internet" target="_blank">Internet</a>&nbsp;và dựa trên mô hình đám mây. ASP.NET Core được phát triển bởi tập đoàn Microsoft và cộng đồng lập trình viên. ASP.NET Core cũng là một framework kiểu module có khả năng thực thi trên framework .NET, Windows và .NET Core đa nền tảng.</p>

<p><img alt="" src="http://www.dammio.com/wp-content/uploads/2018/09/NET-Core_Stack.png" style="height:768px; width:1366px" /></p>

<p>Vị trí .NET Core trong mô hình phát triển .NET</p>

<p>ASP.NET Core còn được xem là sự kết hợp giữa ASP.NET&nbsp;<a href="https://www.dammio.com/glossary/mvc" target="_blank">MVC</a>&nbsp;và ASP.NET Web API tạo thành một mô hình lập trình đơn. Mặc dù được xây dựng mới, ASP.NET Core vẫn có tính tương thích cao với ASP.NET&nbsp;<a href="https://www.dammio.com/glossary/mvc" target="_blank">MVC</a>. Hơn nữa, các ứng dụng ASP.NET Core hỗ trợ kiểu phiên bản “side by side”, tức là cùng chạy trên một máy tính với việc lựa chọn nhiều phiên bản ASP.NET Core khác nhau. Điều này là không thể với các phiên bản ASP.NET trước kia. Phiên bản ASP.NET Core mới nhất tính đến thời điểm viết bài này là ASP.NET 2.1.</p>

<p>Với ASP.NET Core, bạn có thể:</p>

<ul>
	<li>Xây dựng các ứng dụng web, các dịch vụ, ứng dụng IoT và các phần backend mobile.</li>
	<li>Sử dụng các công cụ phát triển ưa thích trên Windows, macOS và Linux.</li>
	<li>Triển khai trên đám mây hoặc tại chỗ.</li>
	<li>Chạy trên .NET Core hoặc .NET Framework.</li>
</ul>

<h2>Tại sao dùng ASP.NET Core?</h2>

<p>Như bạn đã biết, có hàng triệu lập trình viên đã và đang sử dụng ASP.NET 4.x để xây dựng các ứng dụng Web. ASP.NET Core là một phiên bản thiết kế lại của ASP.NET 4.x, với nhiều thay đổi kiến trúc giúp framework nhẹ hơn và có tính module nhiều hơn. Do đó, các lập trình viên có thể tiếp tục xây dựng ứng dụng bằng ASP.NET Core với nền tảng hiệu suất và tính tương thích tốt hơn.</p>

<p>ASP.NET mang lại các lợi ích như sau:</p>

<ul>
	<li>Dùng để xây dựng giao diện Web (Web UI) cũng như các API Web.</li>
	<li>Tích hợp các framework phía client hiện đại và các quy trình làm việc phát triển.</li>
	<li>Hệ thống cấu hình sẵn có trên đám mây.</li>
	<li>Tích hợp sẵn nhúng phụ thuộc.</li>
	<li>Đường ống (pipeline) yêu cầu HTTP mang tính module, hiện suất cao và nhẹ ký.</li>
	<li>Có khả năng lưu trữ (host) ở IIS, Nginx, Apache, Docker, hoặc tự host ở các tiến trình riêng.</li>
	<li>Tạo mới phiên bản app side-by-side với .NET Core.</li>
	<li>Tạo công cụ đơn giản hóa phát triển web hiện đại.</li>
	<li>Khả năng xây dựng, chạy trên Windows, macOS, và Linux.</li>
	<li>Mã nguồn mở và tập trung vào cộng đồng phát triển mã nguồn.</li>
</ul>

<p>ASP.NET Core được cung cấp dưới dạng các gói NuGet. Bạn có thể sử dụng các gói này để tối ưu hóa ứng dụng khi chỉ nhúng những thành phần cần thiết. Trên thực tế, các ứng dụng ASP.NET Core 2.x cũng chỉ yêu cầu một gói NuGet đơn lẻ.</p>
', NULL, CAST(0x07D631024AB189400B AS DateTime2), N'admin', NULL, 1, N'CNPM K61')
SET IDENTITY_INSERT [dbo].[AboutMes] OFF
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [UserName], [PassWord], [Avartar], [DisplayName], [Address], [Email], [Phone], [CreatedBy], [CreatedDate], [ModifiedDate], [IsAdmin], [Status]) VALUES (1, N'admin', N'123456', NULL, N'Tuyên', N'Hà Nội', N'nguyentutuyen444@gmail.com.vn', N'0326557355', N'Tự Tuyên', CAST(0x0790614756B16F400B AS DateTime2), CAST(0x073BB8B6BE4A72400B AS DateTime2), 1, 1)
INSERT [dbo].[Accounts] ([Id], [UserName], [PassWord], [Avartar], [DisplayName], [Address], [Email], [Phone], [CreatedBy], [CreatedDate], [ModifiedDate], [IsAdmin], [Status]) VALUES (3, N'tuyennguyentu', N'tutuyen', NULL, N'Tuyên', N'Hà Nội', N'nguyentutuyen444@gmail.com', N'0326557355', N'Tuyên', NULL, CAST(0x071793BC598A72400B AS DateTime2), 1, 1)
INSERT [dbo].[Accounts] ([Id], [UserName], [PassWord], [Avartar], [DisplayName], [Address], [Email], [Phone], [CreatedBy], [CreatedDate], [ModifiedDate], [IsAdmin], [Status]) VALUES (5, N'admin_1', N'123', NULL, N'Nam', N'Hà Nội', N'nguyentutuyen444@gmail.com', N'0326557355', N'Tuyên', CAST(0x07BFFE96C2B772400B AS DateTime2), NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[CategoryPosts] ON 

INSERT [dbo].[CategoryPosts] ([Id], [CategoryName], [MetaTitle], [MetaKeyword], [MetaDescription], [CreatedDate], [ModifiedDate], [Status]) VALUES (1, N'Tin vắn', N'tin-van', NULL, NULL, CAST(0x07105667BFAE6F400B AS DateTime2), CAST(0x070BEE3275B086400B AS DateTime2), 1)
INSERT [dbo].[CategoryPosts] ([Id], [CategoryName], [MetaTitle], [MetaKeyword], [MetaDescription], [CreatedDate], [ModifiedDate], [Status]) VALUES (4, N'Tin liên quan', N'tin-lien-quan', NULL, NULL, NULL, CAST(0x07189B1EFEAF86400B AS DateTime2), 1)
INSERT [dbo].[CategoryPosts] ([Id], [CategoryName], [MetaTitle], [MetaKeyword], [MetaDescription], [CreatedDate], [ModifiedDate], [Status]) VALUES (5, N'Đua MotoGP', N'dua-motogp', NULL, NULL, CAST(0x075AF03AD5AE86400B AS DateTime2), NULL, 1)
INSERT [dbo].[CategoryPosts] ([Id], [CategoryName], [MetaTitle], [MetaKeyword], [MetaDescription], [CreatedDate], [ModifiedDate], [Status]) VALUES (6, N'Bóng đá', N'bong-da', NULL, NULL, NULL, CAST(0x07EC6DCEF6AE86400B AS DateTime2), 1)
INSERT [dbo].[CategoryPosts] ([Id], [CategoryName], [MetaTitle], [MetaKeyword], [MetaDescription], [CreatedDate], [ModifiedDate], [Status]) VALUES (7, N'Thể thao quốc tế', N'the-thao-quoc-te', NULL, NULL, NULL, CAST(0x076AEA21E7AE86400B AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CategoryPosts] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Contents], [Status]) VALUES (1, N'Hà Nội', 1)
INSERT [dbo].[Contacts] ([Id], [Contents], [Status]) VALUES (2, N'Hải Phòng', 1)
INSERT [dbo].[Contacts] ([Id], [Contents], [Status]) VALUES (3, N'Nam Định', 1)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[FeedBacks] ON 

INSERT [dbo].[FeedBacks] ([Id], [Name], [Phone], [Email], [Address], [Contents], [CreatedDate], [Status]) VALUES (1, N'Tuyên', N'0326557355', N'nguyentutuyen444@gmail.com', N'Hà Nội', N'Đẹp', CAST(0x073C5CB809BB75400B AS DateTime2), 1)
INSERT [dbo].[FeedBacks] ([Id], [Name], [Phone], [Email], [Address], [Contents], [CreatedDate], [Status]) VALUES (2, N'312', N'0326557355', N'nguyentutuyen444@gmail.com', N'312', N'123', CAST(0x077827DFCE9277400B AS DateTime2), 0)
INSERT [dbo].[FeedBacks] ([Id], [Name], [Phone], [Email], [Address], [Contents], [CreatedDate], [Status]) VALUES (3, N'Nam', N'0326557355', N'nguyentutuyen444@gmail.com', N'Hà Nội', N'Hello Xin chào', CAST(0x07A377FA54B38D400B AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[FeedBacks] OFF
SET IDENTITY_INSERT [dbo].[Footers] ON 

INSERT [dbo].[Footers] ([Id], [Contents], [CreatedDate], [Status]) VALUES (2, N'  <div class="footer-top">
            <div class="wrap">
                <div class="col-md-3 col-xs-6 col-sm-4 footer-grid">
                    <h4 class="footer-head">About Us</h4>
                    <p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.</p>
                    <p>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ''Content here.</p>
                </div>
                <div class="col-md-2 col-xs-6 col-sm-2 footer-grid">
                    <h4 class="footer-head">Categories</h4>
                    <ul class="cat">
                        <li><a href="business.html">Business</a></li>
                        <li><a href="technology.html">Technology</a></li>
                        <li><a href="entertainment.html">Entertainment</a></li>
                        <li><a href="sports.html">Sports</a></li>
                        <li><a href="shortcodes.html">Health</a></li>
                        <li><a href="fashion.html">Fashion</a></li>
                    </ul>
                </div>
                <div class="col-md-4 col-xs-6 col-sm-6 footer-grid">
                    <h4 class="footer-head">Flickr Feed</h4>
                    <ul class="flickr">
                        <li><a href="#"><img src="images/bus4.jpg"></a></li>
                        <li><a href="#"><img src="images/bus2.jpg"></a></li>
                        <li><a href="#"><img src="images/bus3.jpg"></a></li>
                        <li><a href="#"><img src="images/tec4.jpg"></a></li>
                        <li><a href="#"><img src="images/tec2.jpg"></a></li>
                        <li><a href="#"><img src="images/tec3.jpg"></a></li>
                        <li><a href="#"><img src="images/bus2.jpg"></a></li>
                        <li><a href="#"><img src="images/bus3.jpg"></a></li>
                        <div class="clearfix"></div>
                    </ul>
                </div>
                <div class="col-md-3 col-xs-12 footer-grid">
                    <h4 class="footer-head">Contact Us</h4>
                    <span class="hq">Our headquaters</span>
                    <address>
                        <ul class="location">
                            <li><span class="glyphicon glyphicon-map-marker"></span></li>
                            <li>CENTER FOR FINANCIAL ASSISTANCE TO DEPOSED NIGERIAN ROYALTY</li>
                            <div class="clearfix"></div>
                        </ul>    
                        <ul class="location">
                            <li><span class="glyphicon glyphicon-earphone"></span></li>
                            <li>+0 561 111 235</li>
                            <div class="clearfix"></div>
                        </ul>    
                        <ul class="location">
                            <li><span class="glyphicon glyphicon-envelope"></span></li>
                            <li><a href="mailto:info@example.com">mail@example.com</a></li>
                            <div class="clearfix"></div>
                        </ul>                        
                    </address>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="footer-bottom">
            <div class="wrap">
                <div class="copyrights col-md-6">
                    <p> © 2015 Express News. All Rights Reserved | Design by  <a href="http://w3layouts.com/"> W3layouts</a></p>
                </div>
                <div class="footer-social-icons col-md-6">
                    <ul>
                        <li><a class="facebook" href="#"></a></li>
                        <li><a class="twitter" href="#"></a></li>
                        <li><a class="flickr" href="#"></a></li>
                        <li><a class="googleplus" href="#"></a></li>
                        <li><a class="dribbble" href="#"></a></li>
                    </ul>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>', CAST(0x07689408F04C87400B AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Footers] OFF
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([Id], [Text], [Link], [DisplayOrder], [Status], [TypeID]) VALUES (1, N'Home', N'/home', N'1', 1, 2)
INSERT [dbo].[Menus] ([Id], [Text], [Link], [DisplayOrder], [Status], [TypeID]) VALUES (2, N'About', N'/about', N'2', 1, 2)
INSERT [dbo].[Menus] ([Id], [Text], [Link], [DisplayOrder], [Status], [TypeID]) VALUES (4, N'Contact', N'/contact', N'3', 1, 2)
INSERT [dbo].[Menus] ([Id], [Text], [Link], [DisplayOrder], [Status], [TypeID]) VALUES (5, N'FeedBack', N'/feedback', N'4', 1, 2)
SET IDENTITY_INSERT [dbo].[Menus] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (19, N'Tôi là tôi', N'/uploads_admin/b5412f2c-ce32-4aa1-bcf3-5d270d6ba1a9_Toi.jpg', N'<p>Xin chào tôi là tôi. Tuyên Nguyễn Tự sinh ngày 27/07/1998. Nơi Sinh Tây Tựu. Nguyên Quán Tây Tựu</p>
', N'toi-la-toi                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', CAST(0x0799562997B687400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Tôi là Nguyễn Tự Tuyên', 0, 1, 1, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (20, N' U22 Việt Nam có vũ khí lợi hại, thầy Park mưu là thành', N'/uploads_admin/2cecd732-15c1-44ee-a238-edc5b9b5ebd1_U22VN.jpg', N'<p>Bóng đá Việt Nam hồi sinh mạnh mẽ từ khi bén lương duyên với HLV Park Hang Seo. Việt Nam vô địch AFF Cup cấp ĐTQG và giờ lần đầu giành HCV ở Đại hội Thể thao Đông Nam Á.</p>

<p>U22 Việt Nam lên ngôi với thành tích bất bại, 6 thắng, 1 hòa”.</p>

<p>Newspim đăng tải chùm ảnh đẹp, đầy cảm xúc của thầy trò HLV Park Hang Seo trên sân Rizal Memorial, ăn mừng giành HCV SEA Games.</p>

<p>Tờ này nhận định:&nbsp;“U22 Indonesia nhỉnh hơn thời gian đầu, nhưng họ đã không đọc được trận đấu và thua cuộc.</p>

<p>U22 Việt Nam thắng đậm 3-0 Indonesia, đạt đến đỉnh cao lần đầu tiên trong 60 năm.</p>

<p>Sau 2 năm 2 tháng dưới sự dẫn dắt của HLV Park Hang Seo, bóng đá Việt Nam trở thành thế lực mạnh nhất Đông Nam Á. Người Việt Nam ăn mừng ở khắp nẻo đường, không ngớt những tiếng hò reo, kèn và cờ đỏ sao vàng tung bay”.</p>

<p>Newspim thông tin thêm: “HLV Park Hang Seo đang chuẩn bị viết một kỳ tích khác: đưa tuyển Việt Nam lọt vào vòng loại cuối cùng World Cup 2022 khu vực châu Á. Thầy Park mơ World Cup.</p>

<p>Việt Nam hiện đang bất bại ở vòng loại thứ 2, xếp nhất bảng D. Ngoài ra, phía trước ông Park cùng U23 Việt Nam là VCK U23 châu Á, cùng bảng D với CHDCND Triều Tiên, Jordan và UAE”.</p>

<p>Truyền thông SK ca ngợi: “Bóng đá Việt Nam chiếm lĩnh, giành vàng ở cả nam và nữ tại SEA Games.</p>

<p>U22 Việt Nam bước lên bục vinh quang sau 60 năm, với chiến thắng ấn tượng trước Indonesia. Trước đó, tuyển nữ Việt Nam đã lấy Vàng (thắng Thái Lan 1-0 trong 120 phút thi đấu)”.</p>
', N'-u22-viet-nam-co-vu-khi-loi-hai,-thay-park-muu-la-thanh                                                                                                                                                                                                                                                                                                                                                                                                                                                             ', CAST(0x07F0A249A0AB88400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Hankyung viết: “Việt Nam trở thành nhà lãnh đạo bóng đá Đông Nam Á khi U22 Việt Nam giành huy chương vàng SEA Games sau 60 năm.', 0, 1, 6, N'U22 Việt Nam')
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (21, N'Nghi vấn Quang Hải giả vờ dính trấn thương để có thể đá cho ĐTQG Nữ', N'/uploads_admin/768f9723-baf2-4a3d-9d03-80b73d773343_QuangHaiWoman.jpg', N'<p>Nguyễn Thị Vạn - cầu thủ nâng tỉ số lên 3-0 cho đội tuyển nữ Việt Nam - được nhiều người nhận xét có gương mặt giống với tiền vệ Quang Hải.</p>

<p>Chiều 29/11, đội tuyển bóng đá nữ Việt Nam có màn đối đầu với Indonesia trong khuôn khổ&nbsp;<em>SEA Games 30</em>.</p>

<p>Sau 90 phút thi đấu, các cô gái áo đỏ có chiến thắng thuyết phục 6-0 và giành tấm vé bước vào bán kết. Trong đó, tiền vệ Nguyễn Thị Vạn là người lập cú đúp nâng tỉ số lên 3-0 sau pha mở màn của Tuyết Dung.</p>

<p>Ngay lập tức, nhiều dân mạng cho rằng Nguyễn Thị Vạn có nhiều nét tương đồng với tiền vệ Quang Hải.&nbsp;Cả hai cũng cùng sinh năm 1997.</p>

<p>Trên một vài diễn đàn về bóng đá, những tấm ảnh ghép Nguyễn Thị Vạn - Quang Hải được nhiều người chia sẻ.&nbsp;</p>
', N'nghi-van-quang-hai-gia-vo-dinh-tran-thuong-de-co-the-da-cho-dtqg-nu                                                                                                                                                                                                                                                                                                                                                                                                                                                 ', CAST(0x070EC0773DAD88400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Nguyễn Thị Vạn - tiền vệ lập cú đúp cho đội tuyển Việt Nam trong trận gặp Indonesia - được dân mạng nhận xét có gương mặt giống Quang Hải', 0, 1, 6, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (22, N'Marc Márquez vô địch MotoGP 2019', N'/uploads_admin/90507bd6-c9f2-42d9-bf70-cde3952b6247_marcMarquez.jpg', N'<p>Trên đường đua ở Thái Lan diễn ra vào ngày Chủ Nhật (6/10), Marc Marquez đã có chiến thắng chặng thứ 8 của mùa giải này. Tay đua 26 tuổi của đội đua Repsol Honda Team nhờ đó đã đạt được 325 điểm sau 15 chặng đấu, hơn tay đua đứng ở vị trí thứ hai là Andrea Dovizioso đội Ducatti tới 110 điểm khi mùa giải chỉ còn bốn chặng là kết thúc.</p>

<p>Chiến thắng tại Thailand Grand Prix đã đánh dấu lần thứ 130 Marc Marquez đứng trên bục Podium trong sự nghiệp thi đấu, lần thứ 91 tại MotoGP và là chiến thắng chặng Grand Prix 53. Với chức vô địch MotoGP lần thứ 6, Marc Marquez hiện đang đứng thứ 3 sau huyền thoại Giacomo Agostini (8 lần vô địch MotoGP) và Valentino Rossi (7 lần). Tuy nhiên, nhiều người tin rằng tay đua trẻ người Tây Ban Nha có khả năng cao đánh bại được 2 huyền thoại trên nhờ phong độ và kỹ năng thi đấu rất ấn tượng.</p>
', N'marc-marquez-vo-dich-motogp-2019                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ', CAST(0x07A2E9CCE7B488400B AS DateTime2), N'admin', CAST(0x07B99874ACB588400B AS DateTime2), N'admin', NULL, N'Tay đua người Tây Ban Nha của đội đua Repsol Honda Team đã giành ngôi vô địch MotoGP 2019 sớm 4 chặng đấu sau khi đánh bại Fabio Quartararo trong một cuộc đấu kịch tính đến nghẹt thở tại Thailand Grand Prix.', 0, 1, 5, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (23, N'DORNA CÔNG BỐ LỊCH THI ĐẤU MOTOGP 2019 TẠM THỜI', N'/uploads_admin/10776233-318c-4546-bb25-e0e99f5735eb_qatar-2018.jpg', N'<p>Ban đầu Dorna tính thêm Mexico và Phần Lan, song cuối cùng phải hủy bỏ kế hoạch vì các lý do khác nhau.</p>

<p>Mùa giải 2019 sẽ bắt đầu từ ngày 10/03/2019 ở Qatar (sớm hơn 1 tuần so với F1) và sẽ kết thúc vào ngày 17/11/2019 ở Valencia như thường lệ.</p>

<p>Thứ tự các chặng đua cũng không có gì thay đổi. Đáng chú ý các tay đua sẽ được nghỉ hè 4 tuần, thay vì chỉ có 3 như năm nay và GP nước Đức vẫn sẽ diễn ra ở trường đua Sachsenring chứ không phải nơi đâu khác.</p>

<table>
	<tbody>
		<tr>
			<td>Date</td>
			<td>Venue</td>
		</tr>
		<tr>
			<td>10/03/2019</td>
			<td>&nbsp;Qatar</td>
		</tr>
		<tr>
			<td>31/03/2019</td>
			<td>&nbsp;Termas de Rio Hondo</td>
		</tr>
		<tr>
			<td>14/04/2019</td>
			<td>&nbsp;Austin</td>
		</tr>
		<tr>
			<td>05/05/2019</td>
			<td>&nbsp;Jerez</td>
		</tr>
		<tr>
			<td>19/05/2019</td>
			<td>&nbsp;Le Mans</td>
		</tr>
		<tr>
			<td>02/06/2019</td>
			<td>&nbsp;Mugello</td>
		</tr>
		<tr>
			<td>16/06/2019</td>
			<td>&nbsp;Barcelona</td>
		</tr>
		<tr>
			<td>30/06/2019</td>
			<td>&nbsp;Assen</td>
		</tr>
		<tr>
			<td>07/07/2019</td>
			<td>&nbsp;Sachsenring</td>
		</tr>
		<tr>
			<td>04/08/2019</td>
			<td>&nbsp;Brno</td>
		</tr>
		<tr>
			<td>11/08/2019</td>
			<td>&nbsp;Red Bull Ring</td>
		</tr>
		<tr>
			<td>25/08/2019</td>
			<td>&nbsp;Silverstone</td>
		</tr>
		<tr>
			<td>15/09/2019</td>
			<td>&nbsp;Misano</td>
		</tr>
		<tr>
			<td>22/09/2019</td>
			<td>&nbsp;Aragon</td>
		</tr>
		<tr>
			<td>06/10/2019</td>
			<td>&nbsp;Buriram</td>
		</tr>
		<tr>
			<td>20/10/2019</td>
			<td>&nbsp;Motegi</td>
		</tr>
		<tr>
			<td>27/10/2019</td>
			<td>&nbsp;Phillip Island</td>
		</tr>
		<tr>
			<td>03/11/2019</td>
			<td>&nbsp;Sepang</td>
		</tr>
		<tr>
			<td>17/11/2019</td>
			<td>&nbsp;Valencia</td>
		</tr>
	</tbody>
</table>
', N'dorna-cong-bo-lich-thi-dau-motogp-2019-tam-thoi                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ', CAST(0x0762DB2E40B588400B AS DateTime2), N'admin', NULL, NULL, NULL, N'MOTOGP 2019 SẼ GIỮ NGUYÊN SỐ CHẶNG ĐUA CỦA MÙA GIẢI 2018, TỨC LÀ 19 CHẶNG ĐUA.', 2, 1, 5, NULL)
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (24, N'Liverpool vào chung kết FIFA Club World Cup', N'/uploads_admin/305629c6-3bb9-4f87-9d2a-723551c52ac0_Liver.jpg', N'<p>Thầy trò HLV Jurgen Klopp bước vào trận bán kết FIFA Club World Cup gặp đối thủ Monterrey với mục tiêu giành chiến thắng không chỉ để tham dự trận chung kết có giá 4 triệu bảng mà còn để gỡ gạc danh dự cho đội trẻ của họ vừa bị loại tại League Cup nước Anh khi bị Aston Villa đánh bại với tỷ số lên đến 5-0.</p>

<p>Những cầu thủ tốt nhất của Liverpool đều đã có mặt tại Qatar, chính vì vậy "Lữ đoàn đỏ" nhanh chóng áp đảo thế trận trước đội bóng được đánh giá yếu hơn đến từ Mexico là Monterrey.</p>

<p>&nbsp;</p>

<p>Đúng như dự đoán, Liverpool sớm mở được tỷ số ngay phút 11. Salah chọc khe thông minh cho Naby Keita thoát xuống rồi dứt điểm quyết đoán hạ gục thủ thành đối phương.</p>

<p>Tuy nhiên ưu thế dẫn bàn của nhà ĐKVĐ UEFA Champions League chỉ tồn tại được vài phút. Rogelio Funes Mori đã có mặt đúng lúc để đá bồi thành bàn sau khi thủ môn Alisson chặn được cú sút căng của Jesus Gallardo.</p>
', N'liverpool-vao-chung-ket-fifa-club-world-cup                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ', CAST(0x07F9AA99578C89400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Liverpool đã có một trận đấu khá vất vả trước Monterrey khi bị cầm hòa trong suốt 90 phút thi đấu chính thức, nhưng Firmino đã nổ súng kịp thời ở những phút bù giờ', 0, 1, 7, N'Alisson bay người hết cỡ để cản phá một pha dứt điểm từ xa của cầu thủ phía Monterrey')
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (25, N'Liverpool đã có một trận đấu khá vất vả trước Monterrey khi bị cầm hòa trong suốt 90 phút thi đấu chính thức, nhưng Firmino đã nổ súng kịp thời ở những phút bù giờ', N'/uploads_admin/4d36a601-aca8-481e-81a4-e727baa6dfa8_ronaldo-1575935993179.jpg', N'<p>C.Ronaldo chia tay Real Madrid vào mùa Hè 2018 để gia nhập Juventus. Từ đó đến nay, thêm 2 Quả bóng vàng nữa được trao và siêu sao người Bồ Đào Nha lần lượt chứng kiến Luka Modric và kỳ phùng địch thủ Lionel Messi giành chiến thắng.</p>

<p>Điều đó đồng nghĩa C.Ronaldo đã bỏ lỡ cơ hội vượt lên trên Messi trong cuộc đua về số lượng QBV và bây giờ một lần nữa bị siêu sao người Argentina vượt mặt. Cụ thể, số QBV của Ronaldo vẫn dừng ở con số 5 còn Messi đã có 6.</p>

<p>Không những thế, cuộc sống của Ronaldo trong màu áo Juve không được êm đẹp cho lắm. Vì thế, siêu sao người Bồ Đào Nha tỏ ra bất mãn và hối hận. Thậm chí CR7 còn thổ lộ với một người đồng đội cũ tại Real Madrid rằng anh hối tiếc vì đã rời đội bóng Hoàng gia.</p>

<p>Thậm chí Ronaldo tin rằng nếu tiếp tục gắn bó với Real, anh đã có thể giành Quả bóng vàng 2018 và 2019. Cần nhấn mạnh thêm, 5 năm cuối trong màu áo Real thì Ronaldo giành tới 4 QBV và 3 danh hiệu Champions League, những thứ bây giờ là xa xỉ với anh tại Turin.</p>

<p>Tuy nhiên theo chiều ngược lại sau khi C.Ronaldo ra đi, Real Madrid cũng sa sút sau ba chức vô địch Champions League liên tiếp. CLB Hoàng gia bị loại ở tứ kết Champions League 2018-19 và không có được hai danh hiệu La Liga, Cúp Nhà vua mùa giải năm ngoái.</p>
', N'liverpool-da-co-mot-tran-dau-kha-vat-va-truoc-monterrey-khi-bi-cam-hoa-trong-suot-90-phut-thi-dau-chinh-thuc,-nhung-firmino-da-no-sung-kip-thoi-o-nhung-phut-bu-gio                                                                                                                                                                                                                                                                                                                                                 ', CAST(0x0729C9377F8C89400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Theo tiết lộ của tờ ABC (Tây Ban Nha). C.Ronaldo đã cảm thấy hối hận khi chia tay Real Madrid để gia nhập Juventus', 1, 1, 7, N'C.Ronaldo chia tay Real Madrid sau ba chức vô địch Champions League liên tiếp')
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (26, N'SEA Games 30: Linh vật Pami đơn giản mà giàu ý nghĩa', N'/uploads_admin/05007b6b-c324-4347-bb2a-4d6c56d1d5d1_pami.jpg', N'<p>Linh vật SEA Games 30 là Pami, được tạo nên bởi 7 quả bóng tròn với 5 màu là vàng, trắng, xanh, đỏ. Theo người Philippines, ''Pami'' có nghĩa là con mèo, nhưng rộng ra, nó nằm trong từ ''Pamilya" tức là gia đình.</p>

<p>Được biết, BTC SEA Games 30 đã phải lựa chọn từ hàng loạt bài thi và tiến hành chấm, thẩm định kín, trước khi công bố rộng rãi ra công chúng – linh vật của SEA Games 30.</p>

<p>Giám đốc điều hành Ủy ban tổ chức SEA Games 2019 (PHILSGOC) Ramon Suzara chia sẻ: "Linh vật của Sea Games 30 sẽ là Pami. Theo đó, Pami sẽ đại diện cho mỗi quốc gia, mỗi VĐV và mỗi người sẽ đoàn kết với nhau. Pami nghĩa là gia đình... nó tượng trưng cho sự vui vẻ".</p>

<p>''Pami'' sẽ xuất hiện bên cạnh 8.750 VĐV đến từ 11 quốc gia tham dự SEA Games 30. Ở Đại hội lần này, sẽ có tổng cộng 529 nội dung ở 56 môn thể thao, diễn ra từ 30/11 đến 10/12/2019.</p>
', N'sea-games-30:-linh-vat-pami-don-gian-ma-giau-y-nghia                                                                                                                                                                                                                                                                                                                                                                                                                                                                ', CAST(0x0788E37E8E8D89400B AS DateTime2), N'admin', NULL, NULL, NULL, N'Linh vật Pami đơn giản mà giàu ý nghĩa', 2, 1, 4, N'Linh vật Pami của SEA Games 30 được giới thiệu tại Philippines')
INSERT [dbo].[Posts] ([Id], [Title], [HinhAnh], [ContentPost], [MetaTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeyword], [MetaDescription], [ViewCount], [Status], [CategoryId], [Note]) VALUES (27, N'U22 Việt Nam được chăm lo ''tận răng'' tại SEA Games', N'/uploads_admin/48058e31-44d0-4693-b49e-9355448b4bc6_cssk.jpg', N'<p>Việc ăn uống cũng được đội ngũ hậu cần VFF làm việc với khách sạn,&nbsp;bố trí một khu vực riêng để phục vụ đội tuyển nhằm giúp thầy trò HLV Park Hang Seo được thoải mái nhất trong điều kiện có thể. Ngoài ra, đội ngũ hậu cần lên đến hơn 20 người cũng giúp đỡ rất nhiều cho đội trong quá trình sinh hoạt và tập luyện tại Philippines.&nbsp;</p>

<p>Theo lịch thi đấu, các trận của bảng B sẽ diễn ra trên 2 sân vận động Rizal Memorial và Binan.&nbsp;</p>

<p>Nếu như sân Rizal Memorial chỉ cách khách sạn đội tuyển khoảng 2km và không phải là vấn đề đáng lo ngại thì sân Binan thực sự là bài toán khi phải mất ít nhất 90 phút di chuyển, chưa tính đến mức độ kẹt xe.</p>

<p>Vì thế, lãnh đạo VFF đã chỉ đạo bộ phận hậu cần thuê thêm một khách sạn gần sân Binan để bố trí ăn nghỉ cho thầy trò HLV Park Hang Seo. Khách sạn này chỉ cách sân Binan khoảng 20-25 phút di chuyển bằng xe buýt nên sẽ giúp toàn đội có được thể trạng và tâm lý tốt nhất.</p>

<p>Chiều 24-11, đội tuyển U22 Việt Nam sẽ có buổi tập làm quen sân Binan. Kết thúc buổi tập, toàn đội tuyển sẽ di chuyển về khách sạn mới nghỉ ngơi chờ trận ra quân gặp U22 Brunei vào ngày 25-11 tới.</p>

<p>Kết thúc trận đấu, đội tuyển U22 Việt Nam sẽ về lại khách sạn Jen ở Manila để thuận tiện cho hoạt động tập luyện, chuẩn bị cho trận đấu kế tiếp.</p>
', N'u22-viet-nam-duoc-cham-lo-''tan-rang''-tai-sea-games                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ', CAST(0x07B41AE2118E89400B AS DateTime2), N'admin', NULL, NULL, NULL, N'VFF đã chủ động kết nối với ban tổ chức nước chủ nhà để tìm hiểu về điều kiện ăn ở, đi lại và cử cán bộ sang tiền trạm, kiểm tra điều kiện thực tế các sân thi đấu, sân tập', 8, 1, 4, N'U22 Việt Nam tổ chức sinh nhật cho Bùi Tiến Dụng trong khu vực ăn dành riêng cho đội ở Manila - Ảnh: ĐOÀN NHẬT')
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Slides] ON 

INSERT [dbo].[Slides] ([Id], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [Status]) VALUES (7, N'/image_slide/704a07a2-7212-4cf3-94d1-64a4759fb3bb_Ronaldo.png', 0, N'/home', N'Zonaldo', CAST(0x07E162912BAA86400B AS DateTime2), N'admin', NULL, 1)
INSERT [dbo].[Slides] ([Id], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [Status]) VALUES (8, N'/image_slide/29146fae-a6e4-4c54-a916-ccbc8dcd45e0_SML.png', 0, N'sml', N'sml', CAST(0x073B052535AA86400B AS DateTime2), N'admin', NULL, 1)
INSERT [dbo].[Slides] ([Id], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [Status]) VALUES (11, N'/image_slide/db081816-12e2-4cc2-a3f0-afd2c5d95bda_GP_1.png', 0, N'/asd', N'1', CAST(0x07E9A7577BAE86400B AS DateTime2), N'admin', NULL, 1)
SET IDENTITY_INSERT [dbo].[Slides] OFF
SET IDENTITY_INSERT [dbo].[TypeMenus] ON 

INSERT [dbo].[TypeMenus] ([Id], [Name]) VALUES (1, N'Menu chính')
INSERT [dbo].[TypeMenus] ([Id], [Name]) VALUES (2, N'Menu phụ')
SET IDENTITY_INSERT [dbo].[TypeMenus] OFF
ALTER TABLE [dbo].[AboutMes] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AboutMes] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CategoryPosts] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CategoryPosts] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Contacts] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[FeedBacks] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FeedBacks] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Footers] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Footers] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Menus] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__CreatedDa__2E1BDC42]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_ViewCount]  DEFAULT ((1)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF__Posts__Status__2F10007B]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Slides] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Slides] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_TypeMenus_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeMenus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_TypeMenus_TypeID]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_CategoryPosts_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CategoryPosts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_CategoryPosts_CategoryId]
GO
