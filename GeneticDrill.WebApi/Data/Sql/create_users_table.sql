create extension if not exists "uuid-ossp";

create table nationalities (
                               id uuid primary key default uuid_generate_v4(),
                               name varchar not null,
                               created_at timestamp default now() not null,
                               created_by varchar not null,
                               updated_at timestamp,
                               updated_by varchar
);

create table nationalities_regions (
                                       id uuid primary key default uuid_generate_v4(),
                                       name varchar not null,
                                       nationality_id uuid references nationalities(id) on delete set null on update cascade,
                                       created_at timestamp default now() not null,
                                       created_by varchar not null,
                                       updated_at timestamp,
                                       updated_by varchar
);

create table dna_platforms (
                               id uuid primary key default uuid_generate_v4(),
                               name varchar not null,
                               created_at timestamp default now() not null,
                               created_by varchar not null,
                               updated_at timestamp,
                               updated_by varchar
);

create table genetic_raw_data (
                                  id uuid primary key default uuid_generate_v4(),
                                  raw_data bytea,
                                  is_deleted boolean default false not null,
                                  dna_platform_id uuid not null references dna_platforms(id) on delete set null on update cascade,
                                  created_at timestamp default now() not null,
                                  created_by varchar not null,
                                  updated_at timestamp,
                                  updated_by varchar
);

create table genetic_raw_data_nationalities (
                                                genetic_raw_data_id uuid references genetic_raw_data(id),
                                                nationality_id uuid references nationalities(id),
                                                created_at timestamp default now() not null,
                                                created_by varchar not null,
                                                updated_at timestamp,
                                                updated_by varchar,
                                                primary key (genetic_raw_data_id, nationality_id)
);

create table users (
                       id uuid primary key default uuid_generate_v4(),
                       first_name varchar not null,
                       middle_name varchar,
                       last_name varchar not null,
                       email varchar unique not null,
                       password varchar,
                       is_blocked boolean default false not null,
                       is_deleted boolean default false not null,
                       login_attempts_count int default 0 not null,
                       token varchar,
                       refresh_token varchar,
                       google_token varchar,
                       google_picture_url varchar,
                       frontend_theme varchar,
                       genetic_raw_data_id uuid references genetic_raw_data(id) on delete set null on update cascade,
                       created_at timestamp default now() not null,
                       created_by varchar not null default 'Database',
                       updated_at timestamp,
                       updated_by varchar
);