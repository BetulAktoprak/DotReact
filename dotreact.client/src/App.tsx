import RouterConfig from "./config/RouterConfig"
import { ToastContainer } from 'react-toastify';
import "react-toastify/dist/ReactToastify.css";
import Spinner from "./components/Spinner";

function App() {

  return (
    <>
      <RouterConfig />
      <ToastContainer autoClose={2500} style={{fontSize:"13px"}} />
      {/* <Spinner /> */}
    </>
  )
}

export default App
