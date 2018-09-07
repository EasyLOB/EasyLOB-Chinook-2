using Chinook.Application;
using Chinook.Data;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void ApplicationChinookDemo()
        {
            Console.WriteLine("\nApplication Chinook Demo\n");

            ApplicationChinookData<Album>();
            ApplicationChinookDTO<AlbumDTO, Album>();

            ApplicationChinookData<Artist>();
            ApplicationChinookDTO<ArtistDTO, Artist>();

            ApplicationChinookData<Customer>();
            ApplicationChinookDTO<CustomerDTO, Customer>();

            ApplicationChinookData<Employee>();
            ApplicationChinookDTO<EmployeeDTO, Employee>();

            ApplicationChinookData<Genre>();
            ApplicationChinookDTO<GenreDTO, Genre>();

            ApplicationChinookData<Invoice>();
            ApplicationChinookDTO<InvoiceDTO, Invoice>();

            ApplicationChinookData<InvoiceLine>();
            ApplicationChinookDTO<InvoiceLineDTO, InvoiceLine>();

            ApplicationChinookData<MediaType>();
            ApplicationChinookDTO<MediaTypeDTO, MediaType>();

            ApplicationChinookData<Playlist>();
            ApplicationChinookDTO<PlaylistDTO, Playlist>();

            ApplicationChinookData<PlaylistTrack>();
            ApplicationChinookDTO<PlaylistTrackDTO, PlaylistTrack>();

            ApplicationChinookData<Track>();
            ApplicationChinookDTO<TrackDTO, Track>();
        }

        private static void ApplicationChinookData<TEntity>()
            where TEntity : ZDataBase
        {
            IChinookGenericApplication<TEntity> application = DIHelper.GetService<IChinookGenericApplication<TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntity> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
        }

        private static void ApplicationChinookDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOBase<TEntityDTO, TEntity>
            where TEntity : ZDataBase
        {
            IChinookGenericApplicationDTO<TEntityDTO, TEntity> application = DIHelper.GetService<IChinookGenericApplicationDTO<TEntityDTO, TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntityDTO> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + "DTO: {0}", enumerable.Count());
        }
    }
}