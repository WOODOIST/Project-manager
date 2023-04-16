using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fact",
                columns: table => new
                {
                    factid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    factname = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fact_pk", x => x.factid);
                });

            migrationBuilder.CreateTable(
                name: "laborcost",
                columns: table => new
                {
                    laborcostid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    laborcostname = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("laborcost_pk", x => x.laborcostid);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    postname = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("post_pk", x => x.postid);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    projectid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    projectname = table.Column<string>(type: "character varying", nullable: false),
                    projectcreationdate = table.Column<DateOnly>(type: "date", nullable: false),
                    projectfinishdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("project_pk", x => x.projectid);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    rolename = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pk", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "scenario",
                columns: table => new
                {
                    scenarioid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    scenarioname = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("scenario_pk", x => x.scenarioid);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    usersurname = table.Column<string>(type: "character varying", nullable: true),
                    username = table.Column<string>(type: "character varying", nullable: true),
                    userpatronymic = table.Column<string>(type: "character varying", nullable: true),
                    userlogin = table.Column<string>(type: "character varying", nullable: true),
                    userpassword = table.Column<string>(type: "character varying", nullable: true),
                    useremail = table.Column<string>(type: "character varying", nullable: true),
                    roleid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pk", x => x.userid);
                    table.ForeignKey(
                        name: "user_fk",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "roleid");
                });

            migrationBuilder.CreateTable(
                name: "plannedlaborcost",
                columns: table => new
                {
                    plannedlaborcostid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    scenarioid = table.Column<int>(type: "integer", nullable: true),
                    laborcostid = table.Column<int>(type: "integer", nullable: true),
                    factid = table.Column<int>(type: "integer", nullable: true),
                    plannedlaborcostfilldate = table.Column<DateOnly>(type: "date", nullable: true),
                    plannedlaborcostpercent = table.Column<decimal>(type: "numeric", nullable: true),
                    projectid = table.Column<int>(type: "integer", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("plannedlaborcost_pk", x => x.plannedlaborcostid);
                    table.ForeignKey(
                        name: "plannedlaborcost_fk",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "plannedlaborcost_fk_1",
                        column: x => x.projectid,
                        principalTable: "project",
                        principalColumn: "projectid");
                    table.ForeignKey(
                        name: "plannedlaborcost_fk_2",
                        column: x => x.factid,
                        principalTable: "fact",
                        principalColumn: "factid");
                    table.ForeignKey(
                        name: "plannedlaborcost_fk_3",
                        column: x => x.scenarioid,
                        principalTable: "scenario",
                        principalColumn: "scenarioid");
                    table.ForeignKey(
                        name: "plannedlaborcost_fk_4",
                        column: x => x.laborcostid,
                        principalTable: "laborcost",
                        principalColumn: "laborcostid");
                });

            migrationBuilder.CreateTable(
                name: "PostDynamic",
                columns: table => new
                {
                    postdynamicid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    postdynamicstartdate = table.Column<DateOnly>(type: "date", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    postid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("postdynamic_pk", x => x.postdynamicid);
                    table.ForeignKey(
                        name: "postdynamic_fk",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "postdynamic_fk_1",
                        column: x => x.postid,
                        principalTable: "Post",
                        principalColumn: "postid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_plannedlaborcost_factid",
                table: "plannedlaborcost",
                column: "factid");

            migrationBuilder.CreateIndex(
                name: "IX_plannedlaborcost_laborcostid",
                table: "plannedlaborcost",
                column: "laborcostid");

            migrationBuilder.CreateIndex(
                name: "IX_plannedlaborcost_projectid",
                table: "plannedlaborcost",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "IX_plannedlaborcost_scenarioid",
                table: "plannedlaborcost",
                column: "scenarioid");

            migrationBuilder.CreateIndex(
                name: "IX_plannedlaborcost_userid",
                table: "plannedlaborcost",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_PostDynamic_postid",
                table: "PostDynamic",
                column: "postid");

            migrationBuilder.CreateIndex(
                name: "IX_PostDynamic_userid",
                table: "PostDynamic",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleid",
                table: "User",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plannedlaborcost");

            migrationBuilder.DropTable(
                name: "PostDynamic");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "fact");

            migrationBuilder.DropTable(
                name: "scenario");

            migrationBuilder.DropTable(
                name: "laborcost");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
