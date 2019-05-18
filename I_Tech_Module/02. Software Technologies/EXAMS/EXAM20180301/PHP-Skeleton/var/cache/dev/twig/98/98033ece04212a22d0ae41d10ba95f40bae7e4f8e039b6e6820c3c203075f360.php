<?php

/* :project:edit.html.twig */
class __TwigTemplate_472af7ecc306755c4e2c7e7cfa39a6fdd2712b7425ef7a3a903b98a8685897c2 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", ":project:edit.html.twig", 1);
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
        $__internal_57c7cf60ad209ff2eb11407dea8e40941db45b9416443150fac687ca86ef64cb = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_57c7cf60ad209ff2eb11407dea8e40941db45b9416443150fac687ca86ef64cb->enter($__internal_57c7cf60ad209ff2eb11407dea8e40941db45b9416443150fac687ca86ef64cb_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:edit.html.twig"));

        $__internal_c4776ac88ec34ea2e611fbe524d41e547fcd7a2df5d2c00ef48356e8c11f5840 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_c4776ac88ec34ea2e611fbe524d41e547fcd7a2df5d2c00ef48356e8c11f5840->enter($__internal_c4776ac88ec34ea2e611fbe524d41e547fcd7a2df5d2c00ef48356e8c11f5840_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", ":project:edit.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_57c7cf60ad209ff2eb11407dea8e40941db45b9416443150fac687ca86ef64cb->leave($__internal_57c7cf60ad209ff2eb11407dea8e40941db45b9416443150fac687ca86ef64cb_prof);

        
        $__internal_c4776ac88ec34ea2e611fbe524d41e547fcd7a2df5d2c00ef48356e8c11f5840->leave($__internal_c4776ac88ec34ea2e611fbe524d41e547fcd7a2df5d2c00ef48356e8c11f5840_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_6f46219260ce643166a6c0e6bd0e546e05f17c1b38fd288cf7b6d8e5b46ec292 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_6f46219260ce643166a6c0e6bd0e546e05f17c1b38fd288cf7b6d8e5b46ec292->enter($__internal_6f46219260ce643166a6c0e6bd0e546e05f17c1b38fd288cf7b6d8e5b46ec292_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_58d3552a11ab183db6c5148fb7c2b833d0e081cea3ca1c747bf501ff7afd90a8 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_58d3552a11ab183db6c5148fb7c2b833d0e081cea3ca1c747bf501ff7afd90a8->enter($__internal_58d3552a11ab183db6c5148fb7c2b833d0e081cea3ca1c747bf501ff7afd90a8_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

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
        echo "\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\">";
        // line 15
        echo twig_escape_filter($this->env, $this->getAttribute(($context["project"] ?? $this->getContext($context, "project")), "description", array()), "html", null, true);
        echo "</textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" value=\"";
        // line 19
        echo twig_escape_filter($this->env, $this->getAttribute(($context["project"] ?? $this->getContext($context, "project")), "budget", array()), "html", null, true);
        echo "\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Edit Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        ";
        // line 26
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Form\TwigRenderer')->searchAndRenderBlock($this->getAttribute(($context["form"] ?? $this->getContext($context, "form")), "_token", array()), 'row');
        echo "
    </form>
</div>
";
        
        $__internal_58d3552a11ab183db6c5148fb7c2b833d0e081cea3ca1c747bf501ff7afd90a8->leave($__internal_58d3552a11ab183db6c5148fb7c2b833d0e081cea3ca1c747bf501ff7afd90a8_prof);

        
        $__internal_6f46219260ce643166a6c0e6bd0e546e05f17c1b38fd288cf7b6d8e5b46ec292->leave($__internal_6f46219260ce643166a6c0e6bd0e546e05f17c1b38fd288cf7b6d8e5b46ec292_prof);

    }

    public function getTemplateName()
    {
        return ":project:edit.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  82 => 26,  72 => 19,  65 => 15,  58 => 11,  49 => 4,  40 => 3,  11 => 1,);
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
            <input class=\"create-title-content\" name=\"project[title]\" value=\"{{ project.title }}\" />
        </div>
        <div class=\"create-description\">
            <div class=\"create-description-label\">Description</div>
            <textarea rows=\"3\" class=\"create-description-content\" name=\"project[description]\">{{ project.description }}</textarea>
        </div>
        <div class=\"create-budget\">
            <div class=\"create-budget-label\">Budget</div>
            <input type=\"number\" min=\"0\" class=\"create-budget-content\" name=\"project[budget]\" value=\"{{ project.budget }}\" />
        </div>
        <div class=\"create-button-holder\">
            <button type=\"submit\" class=\"submit-button\">Edit Project</button>
            <a type=\"button\" href=\"/\" class=\"back-button\">Back</a>
        </div>

        {{ form_row(form._token) }}
    </form>
</div>
{% endblock %}

", ":project:edit.html.twig", "H:\\EXAM\\PHP-Skeleton\\app/Resources\\views/project/edit.html.twig");
    }
}
