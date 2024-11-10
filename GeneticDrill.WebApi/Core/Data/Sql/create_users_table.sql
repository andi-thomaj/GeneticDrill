create extension if not exists "uuid-ossp";

create table nationalities (
                               id uuid primary key default uuid_generate_v4(),
                               name varchar(50) not null,
                               created_at timestamp default now() not null,
                               created_by varchar(50) not null,
                               updated_at timestamp,
                               updated_by varchar(50)
);

create table nationalities_regions (
                                       id uuid primary key default uuid_generate_v4(),
                                       name varchar(50) not null,
                                       nationality_id uuid references nationalities(id) on delete set null on update cascade,
                                       created_at timestamp default now() not null,
                                       created_by varchar(50) not null,
                                       updated_at timestamp,
                                       updated_by varchar(50)
);

create table dna_platforms (
                               id uuid primary key default uuid_generate_v4(),
                               name varchar(50) not null,
                               created_at timestamp default now() not null,
                               created_by varchar(50) not null,
                               updated_at timestamp,
                               updated_by varchar(50)
);

create table genetic_raw_data (
                                  id uuid primary key default uuid_generate_v4(),
                                  raw_data bytea,
                                  is_deleted boolean default false not null,
                                  dna_platform_id uuid not null references dna_platforms(id) on delete set null on update cascade,
                                  created_at timestamp default now() not null,
                                  created_by varchar(50) not null,
                                  updated_at timestamp,
                                  updated_by varchar(50)
);

create table genetic_raw_data_nationalities (
                                                genetic_raw_data_id uuid references genetic_raw_data(id),
                                                nationality_id uuid references nationalities(id),
                                                created_at timestamp default now() not null,
                                                created_by varchar(50) not null,
                                                updated_at timestamp,
                                                updated_by varchar(50),
                                                primary key (genetic_raw_data_id, nationality_id)
);

create table users (
                       id uuid primary key default uuid_generate_v4(),
                       first_name varchar(50) not null,
                       middle_name varchar(50),
                       last_name varchar(50) not null,
                       email varchar(100) unique not null,
                       password varchar(100) not null,
                       is_blocked boolean default false not null,
                       is_deleted boolean default false not null,
                       login_attempts_count int default 0 not null,
                       token varchar(10000),
                       refresh_token varchar(10000),
                       google_token varchar(10000),
                       google_picture_url varchar(500),
                       frontend_theme varchar(50),
                       genetic_raw_data_id uuid references genetic_raw_data(id) on delete set null on update cascade,
                       created_at timestamp default now() not null,
                       created_by varchar(50) not null,
                       updated_at timestamp,
                       updated_by varchar(50)
);