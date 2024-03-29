﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria) {
            Criteria = criteria;
        }

        // Incluir las expressions 
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        // Ordenar registros

        public Expression<Func<T, object>> OrderByAscending { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

      
        protected void AddOrderByAscending(Expression<Func<T, object>> orderByExpression)
        {
            OrderByAscending = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByExpression)
        {
            OrderByDescending = orderByExpression;
        }

        // Paginar registros
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}
