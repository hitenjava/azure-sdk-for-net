﻿using Build.Tasks.Tests.UtilityTests;
using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using Microsoft.Build.Evaluation;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Build.Tasks.Tests.BuildStageTests
{
    public class PreBuildTests : IClassFixture<FileSystemAssetFixture>
    {
        FileSystemAssetFixture fixture;
        CategorizeProjectTaskTest catProjTest;

        public PreBuildTests(FileSystemAssetFixture fix)
        {
            this.fixture = fix;
            catProjTest = new CategorizeProjectTaskTest();
        }

        private SDKCategorizeProjects CategorizeProjects(string scope, int expectedProjectCount)
        {
            SDKCategorizeProjects sdkCat = new SDKCategorizeProjects();
            sdkCat.SourceRootDirPath = catProjTest.sourceRootDir;
            sdkCat.BuildScope = scope;
            sdkCat.IgnoreDirNameForSearchingProjects = Path.Combine(catProjTest.ignoreDir);

            if (sdkCat.Execute())
            {
                Assert.Equal<int>(expectedProjectCount, sdkCat.net452SdkProjectsToBuild.Count());
            }

            return sdkCat;
        }

        [Fact(Skip = "Enable after merge from psSdkJson6")]
        public void BuildOneSdkProject()
        {
            string scope = @"SDKs\Compute";
            SDKCategorizeProjects sdkCat = CategorizeProjects(scope, 1);

            PreBuildTask preBldTsk = new PreBuildTask()
            {
                SdkProjects = sdkCat.net452SdkProjectsToBuild,
                CreatePropsFile = true
            };

            if (preBldTsk.Execute())
            {
                string apiTagPropsFile = preBldTsk.ApiTagPropsFile;

                Assert.NotEmpty(apiTagPropsFile);
                Assert.True(File.Exists(apiTagPropsFile));

                Project proj;
                if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).Count != 0)
                {
                    proj = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).FirstOrDefault<Project>();
                }
                else
                {
                    proj = new Project(apiTagPropsFile);
                }

                ProjectProperty prop = proj.GetProperty("AzureApiTags");
                Assert.NotNull(prop);
            }
        }

        [Fact]
        public void BuildApiMgmtSdkProject()
        {
            string scope = @"SDKs\ApiManagement";
            SDKCategorizeProjects sdkCat = CategorizeProjects(scope, 1);

            PreBuildTask preBldTsk = new PreBuildTask()
            {
                SdkProjects = sdkCat.net452SdkProjectsToBuild,
                CreatePropsFile = true
            };

            if (preBldTsk.Execute())
            {
                string apiTagPropsFile = preBldTsk.ApiTagPropsFile;
                //this.fixture.AssetList.Add(apiTagPropsFile);

                Assert.NotEmpty(apiTagPropsFile);
                Assert.True(File.Exists(apiTagPropsFile));

                Project proj;
                if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).Count != 0)
                {
                    proj = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).FirstOrDefault<Project>();
                }
                else
                {
                    proj = new Project(apiTagPropsFile);
                }

                ProjectProperty prop = proj.GetProperty("AzureApiTag");
                Assert.NotNull(prop);

                ProjectProperty pkgTagProp = proj.GetProperty("PackageTags");
                Assert.NotNull(pkgTagProp);

                proj = null;
            }
        }
    }
}