﻿namespace Unosquare.PocoData
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines standard database fields and methods to store, retrieve, update and delete
    /// data from a backing store.
    /// </summary>
    public interface IPocoDb
    {
        /// <summary>
        /// Gets the database connection object.
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Provides a helper object containing methods to read row data into object properties.
        /// </summary>
        IPocoReader PocoReader { get; }

        /// <summary>
        /// Provides a helper object containing methods to create and delete tables.
        /// </summary>
        IPocoDefinition Definition { get; }

        /// <summary>
        /// Provides a helper object containing methods to generate commands for standard operations.
        /// </summary>
        IPocoCommands Commands { get; }

        /// <summary>
        /// Gets a dynamically generated table proxy containing methods to perform CRUD operations on the given table-mapped type.
        /// </summary>
        /// <typeparam name="T">The type mapped to a database table.</typeparam>
        /// <returns>The table proxy.</returns>
        PocoTableProxy<T> TableProxy<T>() where T : class, new();

        /// <summary>
        /// Selects all records of the given table-mapped type.
        /// </summary>
        /// <param name="T">The table-mapped type.</param>
        /// <returns>An enumerable collection of the records that were retrieved</returns>
        IEnumerable SelectAll(Type T);

        Task<IEnumerable> SelectAllAsync(Type T);

        IEnumerable<T> SelectAll<T>() where T : class, new();

        Task<IEnumerable<T>> SelectAllAsync<T>() where T : class, new();

        IEnumerable SelectMany(Type T, IDbCommand command);

        Task<IEnumerable> SelectManyAsync(Type T, IDbCommand command);

        IEnumerable<T> SelectMany<T>(IDbCommand command) where T : class, new();

        Task<IEnumerable<T>> SelectManyAsync<T>(IDbCommand command) where T : class, new();

        bool SelectSingle(object target);

        Task<bool> SelectSingleAsync(object target);

        Task<int> InsertAsync(object item, bool update);

        int Insert(object item, bool update);

        Task<int> InsertManyAsync(IEnumerable items, bool update);

        int InsertMany(IEnumerable items, bool update);

        Task<int> UpdateAsync(object item);

        int Update(object item);

        Task<int> UpdateManyAsync(IEnumerable items);

        int UpdateMany(IEnumerable items);

        Task<int> DeleteAsync(object obj);

        int Delete(object obj);

        int CountAll(Type T);

        Task<int> CountAllAsync(Type T);
    }
}
