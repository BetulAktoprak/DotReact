import { useEffect, useState } from "react"
import api from '../../services/api';
import { IProduct } from "../../models/IProduct";

function ProductList() {

  const [products, setProducts] = useState<IProduct[]>([]);

  const getProducts = async () => {
    try {
      const response = await api.get("/Products/GetAll");
      console.log("Gelen Veriler:", response.data);
      setProducts(response.data);
    } catch (err) {
      console.error("Veri çekme hatası:", err);
    }
    
  }

  useEffect(() => {
    getProducts();
  }, []);

  return (
    <>
      <h1>ProductList</h1>
      
      {
        products.map((product, index) => (
          <Product key={index} product={product} />
        ))
      }
       
    </>
  )
}

function Product(props){
  return (
    <div>
      <h3>{props.product.name}</h3>
      <p>{props.product.price}</p>
    </div>
  )
}


export default ProductList