using UnityEngine;

namespace DesignPatterns.Factory
{
    public class ProductA : ProductBase
    {
        [SerializeField] 
        private string m_ProductName = "ProductA";
        
        public override string ProductName { get => m_ProductName; set => m_ProductName = value; }

        private ParticleSystem m_ParticleSystem;

        public override void Initialize()
        {
            // Add any unique set up logic here
            gameObject.name = m_ProductName;
            m_ParticleSystem = GetComponentInChildren<ParticleSystem>();

            if (m_ParticleSystem == null)
                return;

            m_ParticleSystem.Stop();
            m_ParticleSystem.Play();
        }
    }
}
