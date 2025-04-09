﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "Genres" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" character varying(100) NOT NULL,
        "Description" character varying(1000) NOT NULL,
        "CreationDate" timestamp with time zone NOT NULL,
        "IsActive" boolean NOT NULL,
        CONSTRAINT "PK_Genres" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "Roles" (
        "Id" text NOT NULL,
        "Name" character varying(256),
        "NormalizedName" character varying(256),
        "ConcurrencyStamp" text,
        CONSTRAINT "PK_Roles" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "Users" (
        "Id" text NOT NULL,
        "FullName" character varying(200) NOT NULL,
        "Birthdate" timestamp with time zone NOT NULL,
        "UserName" character varying(256),
        "NormalizedUserName" character varying(256),
        "Email" character varying(256),
        "NormalizedEmail" character varying(256),
        "EmailConfirmed" boolean NOT NULL,
        "PasswordHash" text,
        "SecurityStamp" text,
        "ConcurrencyStamp" text,
        "PhoneNumber" text,
        "PhoneNumberConfirmed" boolean NOT NULL,
        "TwoFactorEnabled" boolean NOT NULL,
        "LockoutEnd" timestamp with time zone,
        "LockoutEnabled" boolean NOT NULL,
        "AccessFailedCount" integer NOT NULL,
        CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "Books" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Title" character varying(100) NOT NULL,
        "Description" character varying(1000) NOT NULL,
        "ImageUrl" character varying(1000) NOT NULL,
        "Publisher" character varying(100) NOT NULL,
        "PublishDate" timestamp with time zone NOT NULL,
        "Isbn" character varying(13) NOT NULL,
        "Status" integer NOT NULL,
        "GenreId" integer,
        CONSTRAINT "PK_Books" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Books_Genres_GenreId" FOREIGN KEY ("GenreId") REFERENCES "Genres" ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "RoleClaims" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "RoleId" text NOT NULL,
        "ClaimType" text,
        "ClaimValue" text,
        CONSTRAINT "PK_RoleClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_RoleClaims_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "UserAddresses" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "StreetAddress" character varying(200) NOT NULL,
        "StreetNumber" integer NOT NULL,
        "City" character varying(200) NOT NULL,
        "State" char(2) NOT NULL,
        "Zip" char(11) NOT NULL,
        "ApplicationUserId" text NOT NULL,
        CONSTRAINT "PK_UserAddresses" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_UserAddresses_Users_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "UserClaims" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "UserId" text NOT NULL,
        "ClaimType" text,
        "ClaimValue" text,
        CONSTRAINT "PK_UserClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_UserClaims_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "UserLogins" (
        "LoginProvider" text NOT NULL,
        "ProviderKey" text NOT NULL,
        "ProviderDisplayName" text,
        "UserId" text NOT NULL,
        CONSTRAINT "PK_UserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
        CONSTRAINT "FK_UserLogins_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "UserRoles" (
        "UserId" text NOT NULL,
        "RoleId" text NOT NULL,
        CONSTRAINT "PK_UserRoles" PRIMARY KEY ("UserId", "RoleId"),
        CONSTRAINT "FK_UserRoles_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_UserRoles_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE TABLE "UserTokens" (
        "UserId" text NOT NULL,
        "LoginProvider" text NOT NULL,
        "Name" text NOT NULL,
        "Value" text,
        CONSTRAINT "PK_UserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
        CONSTRAINT "FK_UserTokens_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
    VALUES ('373df597-9ca9-4597-95d9-ab18f156021e', '0201f907-f05b-46db-9c4a-8d6bf98e8690', 'User', 'USER');
    INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
    VALUES ('6a8fc41d-a018-4533-9da1-a9bca7f65b09', '347abcd1-2d78-4f91-86ff-606af3620f17', 'Admin', 'ADMIN');
    INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
    VALUES ('ab89debc-bb39-46c0-bc36-5a09f243cb07', '351cb829-f5e2-4a5f-b991-59a8e46c3169', 'Root', 'ROOT');
    INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
    VALUES ('bc82410f-d883-49b7-86be-7b8e5050fda4', '59ebb24e-e168-44ac-a197-a5769622c1fb', 'Employee', 'EMPLOYEE');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    INSERT INTO "RoleClaims" ("Id", "ClaimType", "ClaimValue", "RoleId")
    VALUES (1, 'Root', 'Root', 'ab89debc-bb39-46c0-bc36-5a09f243cb07');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_Books_GenreId" ON "Books" ("GenreId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_RoleClaims_RoleId" ON "RoleClaims" ("RoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE UNIQUE INDEX "RoleNameIndex" ON "Roles" ("NormalizedName");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_UserAddresses_ApplicationUserId" ON "UserAddresses" ("ApplicationUserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_UserClaims_UserId" ON "UserClaims" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_UserLogins_UserId" ON "UserLogins" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "IX_UserRoles_RoleId" ON "UserRoles" ("RoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE INDEX "EmailIndex" ON "Users" ("NormalizedEmail");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    CREATE UNIQUE INDEX "UserNameIndex" ON "Users" ("NormalizedUserName");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    PERFORM setval(
        pg_get_serial_sequence('"RoleClaims"', 'Id'),
        GREATEST(
            (SELECT MAX("Id") FROM "RoleClaims") + 1,
            nextval(pg_get_serial_sequence('"RoleClaims"', 'Id'))),
        false);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250408005213_FirstMigrations') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250408005213_FirstMigrations', '8.0.14');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250409003553_LoanDateReturned') THEN
    CREATE TABLE "Loans" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "UserId" text NOT NULL,
        "BookId" integer NOT NULL,
        "Status" integer NOT NULL,
        "LoanDate" date NOT NULL,
        "ReturnDate" date NOT NULL,
        "DateReturned" date NOT NULL,
        CONSTRAINT "PK_Loans" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Loans_Books_BookId" FOREIGN KEY ("BookId") REFERENCES "Books" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Loans_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250409003553_LoanDateReturned') THEN
    CREATE INDEX "IX_Loans_BookId" ON "Loans" ("BookId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250409003553_LoanDateReturned') THEN
    CREATE INDEX "IX_Loans_UserId" ON "Loans" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20250409003553_LoanDateReturned') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20250409003553_LoanDateReturned', '8.0.14');
    END IF;
END $EF$;
COMMIT;

