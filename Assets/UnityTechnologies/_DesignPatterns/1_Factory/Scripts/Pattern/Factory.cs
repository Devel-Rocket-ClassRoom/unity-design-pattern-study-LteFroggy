using UnityEngine;

namespace DesignPatterns.Factory
{
    /// <summary>
    /// Serves as the base class for all factory types. Factories create instances of products.
    /// </summary>
    public abstract class Factory : MonoBehaviour {

        [SerializeField] private ProductBase m_ProductPrefab;
        
        // Abstract method to get a product instance.
        public virtual IProduct GetProduct(Vector3 position) {
            // Create a Prefab instance and get the product component
            GameObject instance = Instantiate(m_ProductPrefab.gameObject, position, Quaternion.identity);
            ProductBase newProduct = instance.GetComponent<ProductBase>();

            // Each product contains its own logic
            newProduct.Initialize();
            
            return newProduct;
        }

        // Shared method with all factories.
        public string GetLog(IProduct product)
        {
            string logMessage = "Factory: created product " + product.ProductName;
            return logMessage;
        }
    }
}