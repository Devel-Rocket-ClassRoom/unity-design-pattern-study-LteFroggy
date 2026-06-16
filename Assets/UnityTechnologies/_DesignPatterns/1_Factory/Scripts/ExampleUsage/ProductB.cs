using UnityEngine;

namespace DesignPatterns.Factory
{
    public class ProductB : ProductBase
    {
        [SerializeField] 
        private string m_ProductName = "ProductB";
        public override string ProductName { get => m_ProductName; set => m_ProductName = value; }

        private AudioSource audioSource;

        public override void Initialize()
        {
            gameObject.name = m_ProductName;

            // do some logic here
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
                return;

            audioSource.Stop();
            audioSource.Play();

        }
    }
}

