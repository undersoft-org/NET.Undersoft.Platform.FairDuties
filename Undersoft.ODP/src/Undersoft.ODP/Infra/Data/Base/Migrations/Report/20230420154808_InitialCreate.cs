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
                name: "Contacts",
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
                name: "CountryLanguages",
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
                    table.PrimaryKey("PK_CountryLanguages", x => x.Id);
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
                name: "Devices",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    HostName = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    SystemInfo = table.Column<string>(type: "text", nullable: true),
                    SystemVersion = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Devices", x => x.Id);
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
                name: "Personals",
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
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
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
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
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
                name: "PropertiesToProperties",
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
                    table.PrimaryKey("PK_PropertiesToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PropertiesToProperties_Properties_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertiesToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Countries_CountryLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Local",
                        principalTable: "CountryLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Local",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceIdentifiers",
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
                    table.PrimaryKey("PK_DeviceIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceIdentifiers_Devices_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Local",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSessions",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    MACAddress = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_DeviceSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceSessions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "Local",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnionsToProperties",
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
                    table.PrimaryKey("PK_UnionsToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_UnionsToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToProperties_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalsToProperties",
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
                    table.PrimaryKey("PK_PersonalsToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PersonalsToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalsToProperties_Personals_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalsToContacts",
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
                    table.PrimaryKey("PK_PersonalsToContacts", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PersonalsToContacts_Contacts_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalsToContacts_Personals_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalsToDevices",
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
                    table.PrimaryKey("PK_PersonalsToDevices", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PersonalsToDevices_Devices_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalsToDevices_Personals_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    MemberName = table.Column<string>(type: "varchar", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    PersonalId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    LastEstimateOrdinal = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        name: "FK_Members_Personals_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnionsToPlans",
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
                    table.PrimaryKey("PK_UnionsToPlans", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_UnionsToPlans_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToPlans_Plans_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToProperties",
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
                    table.PrimaryKey("PK_AssetsToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToProperties_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
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
                        name: "FK_AssetsToUnions_Unions_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToUnions_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToPlans",
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
                    table.PrimaryKey("PK_AssetsToPlans", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToPlans_Plans_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToPlans_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsToFrameTypeOptionals",
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
                    table.PrimaryKey("PK_AssetsToFrameTypeOptionals", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AssetsToFrameTypeOptionals_Assets_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsToFrameTypeOptionals_Assets_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Assets",
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
                        name: "FK_UnionsToMembers_Unions_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnionsToMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FrameUnit = table.Column<int>(type: "integer", nullable: false),
                    FrameCapacity = table.Column<float>(type: "real", nullable: false),
                    BlockCapacity = table.Column<float>(type: "real", nullable: false),
                    FrameSize = table.Column<int>(type: "integer", nullable: false),
                    BlockSize = table.Column<int>(type: "integer", nullable: false),
                    FrameSeed = table.Column<float>(type: "real", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    LeadershipId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_Groups_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Members_LeadershipId",
                        column: x => x.LeadershipId,
                        principalSchema: "Local",
                        principalTable: "Members",
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
                name: "MemberRoles",
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
                    table.PrimaryKey("PK_MemberRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberRoles_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembersToProperties",
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
                    table.PrimaryKey("PK_MembersToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersToProperties_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersToPlans",
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
                    table.PrimaryKey("PK_MembersToPlans", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersToPlans_Plans_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersToPlans_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
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
                        principalTable: "Contacts",
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
                name: "Setups",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    AttributeId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_Setups_Properties_AttributeId",
                        column: x => x.AttributeId,
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
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_Schedules_Groups_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Groups_GroupViewId",
                        column: x => x.GroupViewId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrameRates",
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
                    OnFrames = table.Column<int>(type: "integer", nullable: false),
                    OffFrames = table.Column<int>(type: "integer", nullable: false),
                    FreeFrames = table.Column<int>(type: "integer", nullable: false),
                    Exchanges = table.Column<int>(type: "integer", nullable: false),
                    DependentByAny = table.Column<bool>(type: "boolean", nullable: false),
                    OptionalFromAny = table.Column<bool>(type: "boolean", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    FrameTypeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_FrameRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrameRates_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameRates_Assets_FrameTypeId",
                        column: x => x.FrameTypeId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameRates_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameRates_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "GroupsToProperties",
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
                    table.PrimaryKey("PK_GroupsToProperties", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_GroupsToProperties_Properties_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToProperties_Groups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupsToPlans",
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
                    table.PrimaryKey("PK_GroupsToPlans", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_GroupsToPlans_Plans_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsToPlans_Groups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Groups",
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
                name: "SetupsToSettings",
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
                    table.PrimaryKey("PK_SetupsToSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SetupsToSettings_Setups_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Setups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetupsToSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frames",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UnionId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    FrameTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    FrameRateId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkMode = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Frames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frames_Unions_UnionId",
                        column: x => x.UnionId,
                        principalSchema: "Local",
                        principalTable: "Unions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frames_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frames_Assets_FrameTypeId",
                        column: x => x.FrameTypeId,
                        principalSchema: "Local",
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frames_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Local",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frames_Members_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrameRatesToFrameRateOptionals",
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
                    table.PrimaryKey("PK_FrameRatesToFrameRateOptionals", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_FrameRatesToFrameRateOptionals_FrameRates_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "FrameRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameRatesToFrameRateOptionals_FrameRates_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "FrameRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FramesToSchedules",
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
                    table.PrimaryKey("PK_FramesToSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_FramesToSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FramesToSchedules_Frames_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FramesToRequests",
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
                    table.PrimaryKey("PK_FramesToRequests", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_FramesToRequests_Requests_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FramesToRequests_Frames_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Frames",
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
                name: "IX_Properties_Ordinal",
                schema: "Local",
                table: "Properties",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesToProperties_RightEntityId",
                schema: "Relation",
                table: "PropertiesToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_AttributeId",
                schema: "Local",
                table: "Setups",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_SetupId",
                schema: "Local",
                table: "Setups",
                column: "SetupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Setups_Ordinal",
                schema: "Local",
                table: "Setups",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_SetupsToSettings_RightEntityId",
                schema: "Relation",
                table: "SetupsToSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Ordinal",
                schema: "Local",
                table: "Contacts",
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
                name: "IX_CountryLanguages_Ordinal",
                schema: "Local",
                table: "CountryLanguages",
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
                name: "IX_DeviceIdentifiers_EntityId",
                schema: "Identifier",
                table: "DeviceIdentifiers",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceIdentifiers_Key",
                schema: "Identifier",
                table: "DeviceIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceIdentifiers_Ordinal",
                schema: "Identifier",
                table: "DeviceIdentifiers",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Ordinal",
                schema: "Local",
                table: "Devices",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSessions_DeviceId",
                schema: "Local",
                table: "DeviceSessions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSessions_Ordinal",
                schema: "Local",
                table: "DeviceSessions",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Unions_Ordinal",
                schema: "Local",
                table: "Unions",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToProperties_RightEntityId",
                schema: "Relation",
                table: "UnionsToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToPlans_RightEntityId",
                schema: "Relation",
                table: "UnionsToPlans",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UnionsToMembers_RightEntityId",
                schema: "Relation",
                table: "UnionsToMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_Ordinal",
                schema: "Local",
                table: "Personals",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalsToProperties_RightEntityId",
                schema: "Relation",
                table: "PersonalsToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalsToContacts_RightEntityId",
                schema: "Relation",
                table: "PersonalsToContacts",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalsToDevices_RightEntityId",
                schema: "Relation",
                table: "PersonalsToDevices",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Ordinal",
                schema: "Local",
                table: "Plans",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Ordinal",
                schema: "Local",
                table: "Schedules",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleId",
                schema: "Local",
                table: "Schedules",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GroupViewId",
                schema: "Local",
                table: "Schedules",
                column: "GroupViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Ordinal",
                table: "Settings",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRates_Ordinal",
                schema: "Local",
                table: "FrameRates",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRates_UnionId",
                schema: "Local",
                table: "FrameRates",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRates_FrameTypeId",
                schema: "Local",
                table: "FrameRates",
                column: "FrameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRates_GroupId",
                schema: "Local",
                table: "FrameRates",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRates_MemberId",
                schema: "Local",
                table: "FrameRates",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameRatesToFrameRateOptionals_RightEntityId",
                schema: "Relation",
                table: "FrameRatesToFrameRateOptionals",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Ordinal",
                schema: "Local",
                table: "Requests",
                column: "Ordinal");

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
                name: "IX_Frames_Ordinal",
                schema: "Local",
                table: "Frames",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_UnionId",
                schema: "Local",
                table: "Frames",
                column: "UnionId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_ScheduleId",
                schema: "Local",
                table: "Frames",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_FrameTypeId",
                schema: "Local",
                table: "Frames",
                column: "FrameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_GroupId",
                schema: "Local",
                table: "Frames",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_MemberId",
                schema: "Local",
                table: "Frames",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FramesToSchedules_RightEntityId",
                schema: "Relation",
                table: "FramesToSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FramesToRequests_RightEntityId",
                schema: "Relation",
                table: "FramesToRequests",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Ordinal",
                schema: "Local",
                table: "Assets",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToProperties_RightEntityId",
                schema: "Relation",
                table: "AssetsToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToUnions_RightEntityId",
                schema: "Relation",
                table: "AssetsToUnions",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToPlans_RightEntityId",
                schema: "Relation",
                table: "AssetsToPlans",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsToFrameTypeOptionals_RightEntityId",
                schema: "Relation",
                table: "AssetsToFrameTypeOptionals",
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
                name: "IX_GroupsToProperties_RightEntityId",
                schema: "Relation",
                table: "GroupsToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsToPlans_RightEntityId",
                schema: "Relation",
                table: "GroupsToPlans",
                column: "RightEntityId");

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
                name: "IX_MemberRoles_Ordinal",
                schema: "Local",
                table: "MemberRoles",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_MemberId",
                schema: "Local",
                table: "MemberRoles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Ordinal",
                schema: "Local",
                table: "Members",
                column: "Ordinal");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId",
                schema: "Local",
                table: "Members",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembersToProperties_RightEntityId",
                schema: "Relation",
                table: "MembersToProperties",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersToPlans_RightEntityId",
                schema: "Relation",
                table: "MembersToPlans",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersToGroups_RightEntityId",
                schema: "Relation",
                table: "MembersToGroups",
                column: "RightEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "PropertiesToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SetupsToSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "DeviceIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "DeviceSessions",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "UnionsToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "UnionsToPlans",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "UnionsToMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PersonalsToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PersonalsToContacts",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PersonalsToDevices",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "FrameRatesToFrameRateOptionals",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "FramesToSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "FramesToRequests",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToUnions",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToPlans",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToFrameTypeOptionals",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToGroups",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AssetsToMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "GroupsToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "GroupsToPlans",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MemberIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "MemberRoles",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "MembersToProperties",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersToPlans",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersToGroups",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "CountryStates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Setups",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "FrameRates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Frames",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "CountryLanguages",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Unions",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Personals",
                schema: "Local");
        }
    }
}
