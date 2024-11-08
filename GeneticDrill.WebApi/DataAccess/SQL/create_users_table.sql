CREATE
EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE TABLE users
(
    "id"                 UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
    first_name           VARCHAR(50)                                 NOT NULL,
    middle_name          VARCHAR(50),
    last_name            VARCHAR(50)                                 NOT NULL,
    email                VARCHAR(100)                                NOT NULL,
    "password"           VARCHAR(100)                                NOT NULL,
    is_blocked           BOOLEAN          DEFAULT FALSE              NOT NULL,
    is_deleted           BOOLEAN          DEFAULT FALSE              NOT NULL,
    login_attempts_count INT              DEFAULT 0                  NOT NULL,
    "token"              VARCHAR(10_000
) ,
    refresh_token VARCHAR(10_000),
    google_token VARCHAR(10_000),
    google_picture_url VARCHAR(500),
    frontend_theme VARCHAR(50),
    genetic_raw_data_id UUID REFERENCES genetic_raw_data("id") ON DELETE SET NULL ON UPDATE CASCADE,
    created_at TIMESTAMP DEFAULT NOW() NOT NULL,
    created_by VARCHAR(50) NOT NULL,
    updated_at TIMESTAMP,
    updated_by VARCHAR(50)
);

CREATE TABLE genetic_raw_data
(
    "id"            UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
    raw_data        bytea,
    is_deleted      BOOLEAN          DEFAULT FALSE              NOT NULL,
    dna_platform_id UUID                                        NOT NULL REFERENCES dna_platforms ("id") ON DELETE SET NULL ON UPDATE CASCADE,
    created_at      TIMESTAMP        DEFAULT NOW()              NOT NULL,
    created_by      VARCHAR(50)                                 NOT NULL,
    updated_at      TIMESTAMP,
    updated_by      VARCHAR(50)
);

CREATE TABLE dna_platforms
(
    "id"       UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
    "name"     VARCHAR(50)                                 NOT NULL,
    created_at TIMESTAMP        DEFAULT NOW()              NOT NULL,
    created_by VARCHAR(50)                                 NOT NULL,
    updated_at TIMESTAMP,
    updated_by VARCHAR(50)
);

CREATE TABLE nationalities
(
    "id"       UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
    "name"     VARCHAR(50)                                 NOT NULL,
    created_at TIMESTAMP        DEFAULT NOW()              NOT NULL,
    created_by VARCHAR(50)                                 NOT NULL,
    updated_at TIMESTAMP,
    updated_by VARCHAR(50)
);

CREATE TABLE nationalities_regions
(
    "id"           UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
    "name"         VARCHAR(50)                                 NOT NULL,
    nationality_id UUID REFERENCES nationalities ("id") ON DELETE SET NULL ON UPDATE CASCADE,
    created_at     TIMESTAMP        DEFAULT NOW()              NOT NULL,
    created_by     VARCHAR(50)                                 NOT NULL,
    updated_at     TIMESTAMP,
    updated_by     VARCHAR(50)
);

CREATE TABLE genetic_raw_data_nationalities
(
    genetic_raw_data_id UUID REFERENCES genetic_raw_data ("id"),
    nationality_id      UUID REFERENCES nationalities ("id"),
    created_at          TIMESTAMP DEFAULT NOW() NOT NULL,
    created_by          VARCHAR(50)             NOT NULL,
    updated_at          TIMESTAMP,
    updated_by          VARCHAR(50),
    PRIMARY KEY (genetic_raw_data_id, nationality_id)
);