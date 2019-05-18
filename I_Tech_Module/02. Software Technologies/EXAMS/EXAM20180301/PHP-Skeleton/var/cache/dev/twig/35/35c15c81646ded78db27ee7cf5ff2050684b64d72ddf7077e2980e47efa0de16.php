<?php

/* :project:delete.html.twig */
class __TwigTemplate_c075bb65d92646ff69ef39d8bd1197147c8f0224228900ab3f50dae18c5aa66e extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", ":project:delete.html.twig", 1);
        $this->blocks = array(
            'main' => array($this, 'block_main'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "base.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_d13a438a416e75e5dfd04511063d3f7c7478afbcece8dc98558915e96eefe2f5 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_d13a438a416e75e5dfd04511063d3f7c7478afbcece8dc98558915e96eefe2f5->enter($__internal_d13a438a416e75e5dfd04511063d3f7c7478afbcece8dc98558915e96eefe2f5_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:delete.html.twig"));

        $__internal_9e3c2fe5ebc1ee61d53aeb6084aea4990f73bdc3235fba9e213555d8765ff7bc = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_9e3c2fe5ebc1ee61d53aeb6084aea4990f73bdc3235fba9e213555d8765ff7bc->enter($__internal_9e3c2fe5ebc1ee61d53aeb6084aea4990f73bdc3235fba9e213555d8765ff7bc_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:delete.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_d13a438a416e75e5dfd04511063d3f7c7478afbcece8dc98558915e96eefe2f5->leave($__internal_d13a438a416e75e5dfd04511063d3f7c7478afbcece8dc98558915e96eefe2f5_prof);

        
        $__internal_9e3c2fe5ebc1ee61d53aeb6084aea4990f73bdc3235fba9e213555d8765ff7bc->leave($__internal_9e3c2fe5ebc1ee61d53aeb6084aea4990f73bdc3235fba9e213555d8765ff7bc_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_3d52ea7c1fa2b25e38f586cadb189569ebe9b1f5699372c9df64261befa0fbac = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_3d52ea7c1fa2b25e38f586cadb189569ebe9b1f5699372c9df64261befa0fbac->enter($__internal_3d52ea7c1fa2b25e38f586cadb189569ebe9b1f5699372c9df64261befa0fbac_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_b372c756cb22f1aea1c5358dbe9c57223aa92dfb093ccf69469b60e2c26b7c28 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_b372c756cb22f1aea1c5358dbe9c57223aa92dfb093ccf69469b60e2c26b7c28->enter($__internal_b372c756cb22f1aea1c5358dbe9c57223aa92dfb093ccf69469b60e2c26b7c28_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Delete Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" value=\"";
        // line 11
        echo twig_escape_filter($this->env, $this->getAttribute(($context["project"] ?? $this->getContext($context, "project")), "title", array()), "html", null, true);
        echo "\" disabled=\"disabled\"/>
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"
                      disabled=\"disabled\">";
        // line 16
        echo twig_escape_filter($this->env, $this->getAttribute(($context["project"] ?? $this->getContext($context, "project")), "description", array()), "html", null, true);
        echo "</textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" value=\"";
        // line 20
        echo twig_escape_filter($this->env, $this->getAttribute(($context["project"] ?? $this->getContext($context, "project")), "budget", array()), "html", null, true);
        echo "\"
                   disabled=\"disabled\"/>
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Delete Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        ";
        // line 28
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Form\TwigRenderer')->searchAndRenderBlock($this->getAttribute(($context["form"] ?? $this->getContext($context, "form")), "_token", array()), 'row');
        echo "
    </form>
</div>
";
        
        $__internal_b372c756cb22f1aea1c5358dbe9c57223aa92dfb093ccf69469b60e2c26b7c28->leave($__internal_b372c756cb22f1aea1c5358dbe9c57223aa92dfb093ccf69469b60e2c26b7c28_prof);

        
        $__internal_3d52ea7c1fa2b25e38f586cadb189569ebe9b1f5699372c9df64261befa0fbac->leave($__internal_3d52ea7c1fa2b25e38f586cadb189569ebe9b1f5699372c9df64261befa0fbac_prof);

    }

    public function getTemplateName()
    {
        return ":project:delete.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  84 => 28,  73 => 20,  66 => 16,  58 => 11,  49 => 4,  40 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends \"base.html.twig\" %}

{% block main %}
<div class=\"wrapper\">
    <form class=\"project-create\" method=\"post\">
        <div class=\"create-header\">
            Delete Project
        </div>
        <div class=\"create-title\">
            <div class=\"create-title-label\">Title</div>
            <input class=\"create-title-content\" name=\"project[title]\" value=\"{{ project.title }}\" disabled=\"disabled\"/>
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\"
                      disabled=\"disabled\">{{ project.description }}</textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" value=\"{{ project.budget }}\"
                   disabled=\"disabled\"/>
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Delete Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        {{ form_row(form._token) }}
    </form>
</div>
{% endblock %}", ":project:delete.html.twig", "H:\\EXAM\\PHP-Skeleton\\app/Resources\\views/project/delete.html.twig");
    }
}
