﻿using System;
using LaserExpertise.DAL.EF;
using LaserExpertise.DAL.Repositories;

namespace LaserExpertise.DAL.Models.Information
{
    public class UnitOfWork : IDisposable
    {
        private LaserExpertiseContext db = new LaserExpertiseContext();

        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private PictureRepository pictureRepository;
        private ArtworkRepository artworkRepository;

        public PictureRepository Pictures
        {
            get
            {
                if (pictureRepository == null)
                    pictureRepository = new PictureRepository(db);
                return pictureRepository;
            }
        }


        public ArtworkRepository Artworks
        {
            get
            {
                if (artworkRepository == null)
                    artworkRepository = new ArtworkRepository(db);
                return artworkRepository;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }
        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
      
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                  if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}