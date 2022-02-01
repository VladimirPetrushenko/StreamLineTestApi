import { useContext, useEffect } from 'react';
import { CheckUser } from './Api';
import './App.css';
import { AppContext } from './components/common/Context';
import { Footer } from './components/common/Footer';
import { Header } from './components/common/Header';
import { RoutesComponent } from './pages/simple-page/RoutesComponent';

function App() {
  const {setIsAuth, setUserName} = useContext(AppContext);

  useEffect(() => {
    CheckUser().then(data => {
      setIsAuth(true);
      setUserName(data);
    }).catch(error => {
      setIsAuth(false);
    });
  }, [setIsAuth, setUserName])


  return (
    <div>
      <Header />
      <div className="bg-warning text-dark bg-opacity-25 position-relative pb-0 pt-0">
        <div className="container content h-100 bg-warning bg-opacity-50 ps-0 pt-0">
          <RoutesComponent />
        </div>
      </div>
      <Footer />
    </div>
  );
}

export default App;
