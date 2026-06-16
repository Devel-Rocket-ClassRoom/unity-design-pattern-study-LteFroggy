using UnityEngine;

namespace DesignPatterns.Factory
{
    public class ConcreteFactoryB : Factory
    {
        public override IProduct GetProduct(Vector3 position)
        {
            ProductBase newProduct = base.GetProduct(position) as ProductBase;
            
            // Add any unique behavior to this factory
            newProduct!.gameObject.name = newProduct.ProductName;
            Debug.Log(GetLog(newProduct));
            
            return newProduct;
        }
    }
}
