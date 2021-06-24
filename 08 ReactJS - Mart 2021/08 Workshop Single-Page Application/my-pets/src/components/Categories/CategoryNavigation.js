import { NavLink } from 'react-router-dom';

const CategoryNavigation = () => {
  return (
    <nav className="navbar">
      <ul>
        <li><NavLink activeClassName="category-selected" to="/categories/all">All</NavLink></li>
        <li><NavLink activeClassName="category-selected" to="/categories/cats">Cats</NavLink></li>
        <li><NavLink activeClassName="category-selected" to="/categories/dogs">Dogs</NavLink></li>
        <li><NavLink activeClassName="category-selected" to="/categories/parrots">Parrots</NavLink></li>
        <li><NavLink activeClassName="category-selected" to="/categories/reptiles">Reptiles</NavLink></li>
        <li><NavLink activeClassName="category-selected" to="/categories/other">Other</NavLink></li>
      </ul>

      <style jsx>{`
          .category-selected {
              background-color: lightgreen !important;
          }
          `}</style>
    </nav>
  );
};

export default CategoryNavigation;