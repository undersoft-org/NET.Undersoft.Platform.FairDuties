using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Undersoft.ODP.Infra.Data.Base.Migrations.Report
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Local");

            migrationBuilder.EnsureSchema(
                name: "Relation");

            migrationBuilder.EnsureSchema(
                name: "Identifier");

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    HostName = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    MachineName = table.Column<string>(type: "text", nullable: true),
                    OsVersion = table.Column<string>(type: "text", nullable: true),
                    ClientDoamin = table.Column<string>(type: "text", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Notices = table.Column<string>(type: "text", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "text", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unions",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "varchar", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Notices = table.Column<string>(type: "text", nullable: true),
                    LastEstimateOrdinal = table.Column<int>(type: "integer", nullable: false),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vertices",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartBlock = table.Column<int>(type: "integer", nullable: false),
                    EndBlock = table.Column<int>(type: "integer", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToAssetOptionals",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToAssetOptionals", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToAssetOptionals_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToAssetOptionals_Assets_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIdentifiers_Clients_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Local",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    Host = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    HID = table.Column<string>(type: "text", nullable: true),
                    ConnectedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DurationTime = table.Column<int>(type: "integer", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Local",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Continent = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Local",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Local",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    ProfilelId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    LastEstimateOrdinal = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Profiles_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesToClients",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesToClients", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ProfilesToClients_Clients_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilesToClients_Profiles_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesToContacts",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesToContacts", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ProfilesToContacts_Contacts_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilesToContacts_Profiles_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToPropertys_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilesToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilesToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ProfilesToPropertys_Profiles_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilesToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertysToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertysToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PropertysToPropertys_Properties_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertysToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToUnions",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToUnions", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToUnions_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToUnions_Unions_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnionsToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionsToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_UnionsToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToPropertys_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToVertexs",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToVertexs", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToVertexs_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToVertexs_Vertices_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnionsToVertexs",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionsToVertexs", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_UnionsToVertexs_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToVertexs_Vertices_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryStates",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryStates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Local",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToMembers",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToMembers_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "varchar", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    BlockCapacity = table.Column<float>(type: "real", nullable: false),
                    SectorCapacity = table.Column<float>(type: "real", nullable: false),
                    BlockSize = table.Column<int>(type: "integer", nullable: false),
                    SectorSize = table.Column<int>(type: "integer", nullable: false),
                    BlockSeed = table.Column<float>(type: "real", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    LeadershipId = table.Column<long>(type: "bigint", nullable: true),
                    VectorId = table.Column<long>(type: "bigint", nullable: true),
                    LastEstimateOrdinal = table.Column<int>(type: "integer", nullable: false),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Members_LeadershipId",
                        column: x => x.LeadershipId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberIdentifiers_Members_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembersToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersToPropertys_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersToVertexs",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersToVertexs", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersToVertexs_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersToVertexs_Vertices_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnionsToMembers",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionsToMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_UnionsToMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToMembers_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CityName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    StreetName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    BuildingNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    ApartmentNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Postcode = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    Notices = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Local",
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Local",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_CountryStates_StateId",
                        column: x => x.StateId,
                        principalSchema: "Local",
                        principalTable: "CountryStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToGroups",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsToGroups", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToGroups_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToGroups_Groups_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Checksum = table.Column<double>(type: "double precision", nullable: false),
                    Rank = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    Weekly = table.Column<int>(type: "integer", nullable: false),
                    Monthly = table.Column<int>(type: "integer", nullable: false),
                    Yearly = table.Column<int>(type: "integer", nullable: false),
                    Weekends = table.Column<int>(type: "integer", nullable: false),
                    Holidays = table.Column<int>(type: "integer", nullable: false),
                    OnDuties = table.Column<int>(type: "integer", nullable: false),
                    OffDuties = table.Column<int>(type: "integer", nullable: false),
                    FreeDuties = table.Column<int>(type: "integer", nullable: false),
                    Exchanges = table.Column<int>(type: "integer", nullable: false),
                    DependentByAny = table.Column<bool>(type: "boolean", nullable: false),
                    OptionalFromAny = table.Column<bool>(type: "boolean", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    AssetId = table.Column<long>(type: "bigint", nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupsToPropertys",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsToPropertys", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_GroupsToPropertys_Groups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToPropertys_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupsToVertexs",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsToVertexs", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_GroupsToVertexs_Groups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToVertexs_Vertices_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersToGroups",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersToGroups", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersToGroups_Groups_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersToGroups_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsView = table.Column<bool>(type: "boolean", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    VectorId = table.Column<long>(type: "bigint", nullable: true),
                    GroupViewId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Groups_GroupViewId",
                        column: x => x.GroupViewId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Groups_VectorId",
                        column: x => x.VectorId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    PropertyId = table.Column<long>(type: "bigint", nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setups_Groups_SetupId",
                        column: x => x.SetupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Setups_Members_SetupId",
                        column: x => x.SetupId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Setups_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Setups_Unions_SetupId",
                        column: x => x.SetupId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesToEstimateOptionals",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesToEstimateOptionals", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_EstimatesToEstimateOptionals_Estimates_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimatesToEstimateOptionals_Estimates_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    AssetId = table.Column<long>(type: "bigint", nullable: true),
                    VectorId = table.Column<long>(type: "bigint", nullable: true),
                    EstimateId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Mode = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    HasRequests = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequested = table.Column<bool>(type: "boolean", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duties_Assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Schedules_VectorId",
                        column: x => x.VectorId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetupsToOptions",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupsToOptions", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SetupsToOptions_Options_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetupsToOptions_Setups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Setups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutysToRequests",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutysToRequests", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_DutysToRequests_Duties_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Duties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutysToRequests_Requests_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutysToVectors",
                schema: "Relation",
                columns: table => new
                {
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    TargetId = table.Column<long>(type: "bigint", nullable: false),
                    TargetType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    CodeNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutysToVectors", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_DutysToVectors_Duties_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Duties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutysToVectors_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                schema: "Local",
                table: "Addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "Local",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Ordinal",
                schema: "Local",
                table: "Addresses",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                schema: "Local",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Ordinal",
                schema: "Local",
                table: "Assets",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToAssetOptionals_RightEntityId",
                schema: "Relation",
                table: "AssetsToAssetOptionals",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToGroups_RightEntityId",
                schema: "Relation",
                table: "AssetsToGroups",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToMembers_RightEntityId",
                schema: "Relation",
                table: "AssetsToMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToPropertys_RightEntityId",
                schema: "Relation",
                table: "AssetsToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToUnions_RightEntityId",
                schema: "Relation",
                table: "AssetsToUnions",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToVertexs_RightEntityId",
                schema: "Relation",
                table: "AssetsToVertexs",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdentifiers_EntityId",
                schema: "Identifier",
                table: "ClientIdentifiers",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdentifiers_Key",
                schema: "Identifier",
                table: "ClientIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdentifiers_Ordinal",
                schema: "Identifier",
                table: "ClientIdentifiers",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Ordinal",
                schema: "Local",
                table: "Clients",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Ordinal",
                schema: "Local",
                table: "Locales",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                schema: "Local",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                schema: "Local",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Ordinal",
                schema: "Local",
                table: "Countries",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_CountryStates_CountryId",
                schema: "Local",
                table: "CountryStates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryStates_Ordinal",
                schema: "Local",
                table: "CountryStates",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Ordinal",
                schema: "Local",
                table: "Currencies",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_AssetId",
                schema: "Local",
                table: "Duties",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_GroupId",
                schema: "Local",
                table: "Duties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_MemberId",
                schema: "Local",
                table: "Duties",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_Ordinal",
                schema: "Local",
                table: "Duties",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_UnionId",
                schema: "Local",
                table: "Duties",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_VectorId",
                schema: "Local",
                table: "Duties",
                column: "VectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DutysToRequests_RightEntityId",
                schema: "Relation",
                table: "DutysToRequests",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DutysToVectors_RightEntityId",
                schema: "Relation",
                table: "DutysToVectors",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_AssetId",
                schema: "Local",
                table: "Estimates",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_GroupId",
                schema: "Local",
                table: "Estimates",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_MemberId",
                schema: "Local",
                table: "Estimates",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Ordinal",
                schema: "Local",
                table: "Estimates",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_UnionId",
                schema: "Local",
                table: "Estimates",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesToEstimateOptionals_RightEntityId",
                schema: "Relation",
                table: "EstimatesToEstimateOptionals",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LeadershipId",
                schema: "Local",
                table: "Groups",
                column: "LeadershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Ordinal",
                schema: "Local",
                table: "Groups",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UnionId",
                schema: "Local",
                table: "Groups",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsToPropertys_RightEntityId",
                schema: "Relation",
                table: "GroupsToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsToVertexs_RightEntityId",
                schema: "Relation",
                table: "GroupsToVertexs",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Ordinal",
                schema: "Local",
                table: "Languages",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentifiers_EntityId",
                schema: "Identifier",
                table: "MemberIdentifiers",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentifiers_Key",
                schema: "Identifier",
                table: "MemberIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentifiers_Ordinal",
                schema: "Identifier",
                table: "MemberIdentifiers",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                schema: "Local",
                table: "Members",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_Ordinal",
                schema: "Local",
                table: "Members",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_MembersToGroups_RightEntityId",
                schema: "Relation",
                table: "MembersToGroups",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersToPropertys_RightEntityId",
                schema: "Relation",
                table: "MembersToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersToVertexs_RightEntityId",
                schema: "Relation",
                table: "MembersToVertexs",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Ordinal",
                table: "Options",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Ordinal",
                schema: "Local",
                table: "Profiles",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesToClients_RightEntityId",
                schema: "Relation",
                table: "ProfilesToClients",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesToContacts_RightEntityId",
                schema: "Relation",
                table: "ProfilesToContacts",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilesToPropertys_RightEntityId",
                schema: "Relation",
                table: "ProfilesToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Ordinal",
                schema: "Local",
                table: "Properties",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_PropertysToPropertys_RightEntityId",
                schema: "Relation",
                table: "PropertysToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GroupId",
                schema: "Local",
                table: "Requests",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_MemberId",
                schema: "Local",
                table: "Requests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Ordinal",
                schema: "Local",
                table: "Requests",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MemberId",
                schema: "Local",
                table: "Roles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Ordinal",
                schema: "Local",
                table: "Roles",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GroupViewId",
                schema: "Local",
                table: "Schedules",
                column: "GroupViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Ordinal",
                schema: "Local",
                table: "Schedules",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_VectorId",
                schema: "Local",
                table: "Schedules",
                column: "VectorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClientId",
                schema: "Local",
                table: "Sessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Ordinal",
                schema: "Local",
                table: "Sessions",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_Ordinal",
                schema: "Local",
                table: "Setups",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_PropertyId",
                schema: "Local",
                table: "Setups",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_SetupId",
                schema: "Local",
                table: "Setups",
                column: "SetupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SetupsToOptions_RightEntityId",
                schema: "Relation",
                table: "SetupsToOptions",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Unions_Ordinal",
                schema: "Local",
                table: "Unions",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToMembers_RightEntityId",
                schema: "Relation",
                table: "UnionsToMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToPropertys_RightEntityId",
                schema: "Relation",
                table: "UnionsToPropertys",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToVertexs_RightEntityId",
                schema: "Relation",
                table: "UnionsToVertexs",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_Ordinal",
                schema: "Local",
                table: "Vertices",
                column: "Ordinal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "AssetsToAssetOptionals",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToGroups",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToUnions",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToVertexs",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ClientIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "DutysToRequests",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "DutysToVectors",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "EstimatesToEstimateOptionals",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "GroupsToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "GroupsToVertexs",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MemberIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "MembersToGroups",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersToVertexs",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ProfilesToClients",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ProfilesToContacts",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ProfilesToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PropertysToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "SetupsToOptions",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "UnionsToMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "UnionsToPropertys",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "UnionsToVertexs",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "CountryStates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Duties",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Estimates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Locales",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Setups",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Vertices",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Unions",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "Local");
        }
    }
}
