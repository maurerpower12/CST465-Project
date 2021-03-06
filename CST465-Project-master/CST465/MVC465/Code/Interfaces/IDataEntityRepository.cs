﻿using System.Collections.Generic;
public interface IDataEntityRepository<T> where T: IDataEntity
{
    T Get(int id);
    void Save(T entity);
    List<T> GetList();
    void Remove(int iD);
}