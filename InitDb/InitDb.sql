CREATE TABLE "user" (
    "id" UUID,
    "email" VARCHAR PRIMARY KEY,
    "hash_password" TEXT NOT NULL
);