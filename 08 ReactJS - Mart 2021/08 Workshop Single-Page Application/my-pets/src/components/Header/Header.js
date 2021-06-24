const Header = () => {
  return (
    <header id="site-header">
      <nav class="navbar">
        <section class="navbar-dashboard">
          <div class="first-bar">
            <a href="#">Dashboard</a>
            <a class="button" href="#">
              My Pets
            </a>
            <a class="button" href="#">
              Add Pet
            </a>
          </div>
          <div class="second-bar">
            <ul>
              <li>Welcome!</li>
              <li>
                <a href="#">
                  <i class="fas fa-sign-out-alt"></i> Logout
                </a>
              </li>
            </ul>
          </div>
        </section>
        <section class="navbar-anonymous">
          <ul>
            <li>
              <a href="#">
                <i class="fas fa-user-plus"></i> Register
              </a>
            </li>
            <li>
              <a href="#">
                <i class="fas fa-sign-in-alt"></i> Login
              </a>
            </li>
          </ul>
        </section>
      </nav>

      <style jsx>{`
        nav.navbar {
          display: flex;
          flex-wrap: wrap;
          justify-content: flex-end;
          align-self: center;
          letter-spacing: 0.05rem;
          background: #234465;
          padding: 0.8rem 1rem;
          color: white;
        }
        #site-header > nav > section.navbar-dashboard > a {
          list-style: none;
          text-decoration: none;
          align-self: center;
          font-weight: bold;
          font-size: 1.5rem;
          color: white;
        }
        #site-header
          > nav
          > section.navbar-dashboard
          > form
          > input[type="text"],
        #site-header
          > nav
          > section.navbar-anonymous
          > ul
          > li:nth-child(1)
          > a,
        #site-header > nav > section.navbar-user > ul > li:nth-child(1),
        #site-header
          > nav
          > section.navbar-dashboard
          > ul
          > li:nth-child(1)
          > a {
          margin-right: 0.5rem;
        }

        nav.navbar ul {
          background: transparent;
          padding: 0.5rem;
          border-radius: 0.3rem;
          margin: 0;
        }
        nav.navbar ul li {
          display: block;
          list-style: none outside;
          position: relative;
        }
        nav.navbar ul li a {
          display: block;
          padding: 0.4rem 0.8rem;
          border-radius: 0.4rem;
          text-decoration: none;
          font-weight: bold;
          background: cadetblue;
          color: rgb(255, 255, 255);
        }
        .button:hover,
        nav.navbar ul li a:hover,
        nav.navbar ul li:hover > a {
          background: rgb(248, 215, 107);
          color: rgb(0, 0, 0);
          font-weight: bold;
        }
      `}</style>
    </header>
  );
};

export default Header;
