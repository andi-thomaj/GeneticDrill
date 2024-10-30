CREATE TABLE users (
                       "id" UUID PRIMARY KEY DEFAULT uuid_generate_v4() NOT NULL,
                       first_name VARCHAR(50) NOT NULL,
                       middle_name VARCHAR(50),
                       last_name VARCHAR(50) NOT NULL,
                       email VARCHAR(100) NOT NULL,
                       "password" VARCHAR(100) NOT NULL,
                       is_blocked BOOLEAN DEFAULT FALSE NOT NULL,
                       is_deleted BOOLEAN DEFAULT FALSE NOT NULL,
                       login_attempts_count INT DEFAULT 0 NOT NULL,
                       "token" VARCHAR(10_000),
	refresh_token VARCHAR(10_000),
	google_token VARCHAR(10_000),
	google_picture_url VARCHAR(500),
	frontend_theme VARCHAR(50),
	genetic_data_id UUID,
	created_at TIMESTAMP DEFAULT NOW() NOT NULL,
	created_by VARCHAR(50) NOT NULL,
	updated_at TIMESTAMP,
	updated_by VARCHAR(50)
);

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
