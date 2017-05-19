using Chinook.Application;
using Chinook.Data;
using Chinook.Persistence;
using EasyLOB;
using EasyLOB.Application;
using System;

namespace Chinook
{
    public interface IChinookApplication : IDisposable
    {
        #region Properties

        IDIManager DIManager { get; }

        #endregion

        #region Methods

        bool Clean(ZOperationResult operationResult, string directory);

        bool Reset(ZOperationResult operationResult, IChinookUnitOfWork unitOfWork);

        // TXT

        bool ExportGenreTXT(ZOperationResult operationResult, string fileDirectory, IChinookGenericApplication<Genre> genreApplication,
            out string filePath);

        bool ImportGenreTXTApplication(ZOperationResult operationResult, string filePath, IChinookGenericApplication<Genre> genreApplication);

        bool ImportGenreTXTPersistence(ZOperationResult operationResult, string filePath, IChinookUnitOfWork unitOfWork);

        // XLSX

        bool ExportAlbumByArtistXLSX(ZOperationResult operationResult, string templateDirectory, string fileDirectory,
            out string filePath);

        bool ExportGenreXLSX(ZOperationResult operationResult, string fileDirectory,
            out string filePath);

        bool ImportGenreXLSX(ZOperationResult operationResult, string filePath, IChinookGenericApplication<Genre> genreApplication);

        #endregion Methods
    }
}