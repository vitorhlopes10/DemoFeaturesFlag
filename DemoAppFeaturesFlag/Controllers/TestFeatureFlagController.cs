using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Threading.Tasks;

namespace DemoAppFeaturesFlag.Controllers
{
    [Route("/api/[controller]")]
    public class TestFeatureFlagController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public TestFeatureFlagController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet]
        [FeatureGate(MyFlags.TestFlagNewFeature)]
        public async Task<IActionResult> GetTestAsync()
        {
            var featureActive = await _featureManager.IsEnabledAsync("TestFlagNewFeature");
            return Ok(featureActive);
        }
    }
}
