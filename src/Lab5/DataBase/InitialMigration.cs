namespace DataBase;

public class InitialMigration
{
    public string GetUpSql =>
        """
        create table if not exists accounts (
            account_number bigint primary key,
            pin bigint not null,
            balance bigint not null
        );
        """;

    public string GetDownSql =>
        """
        drop table if exists accounts;
        """;
}